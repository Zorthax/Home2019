using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<InventorySlot> slots = new List<InventorySlot>();
    Camera cam;

    static List<InventorySlot> slots_s;

    public Transform pick;
    public Vector3 hitRotation;
    Vector3 idleRotation;
    bool swinging;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        slots_s = slots;
        idleRotation = pick.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Vector3.Distance(pick.localEulerAngles, idleRotation) < 15f)
        {
            //swinging = false;
            if (Input.GetMouseButtonDown(0))
            {
                swinging = true;
            }
            
        }
        if (Vector3.Distance(pick.localEulerAngles, hitRotation) < 0.1f)
        {
            if (swinging)
            {
                swinging = false;
            
                RaycastHit hit;

                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 6))
                {
                    //if hitting a breakable like a tree or rock
                    BreakableResource thing = hit.transform.GetComponentInParent<BreakableResource>();
                    if (thing)
                    {
                        thing.TakeDamage(1);
                        Destroy(Instantiate(thing.particleEffect, hit.point + Vector3.down * 0.2f, Quaternion.identity) as GameObject, 2);
                    }
                }
            }
        }

        if (swinging)
            pick.localRotation = Quaternion.Lerp(Quaternion.Euler(pick.localEulerAngles), Quaternion.Euler(hitRotation), 50f * Time.deltaTime);
        else
            pick.localEulerAngles = Vector3.Lerp(pick.localEulerAngles, idleRotation, 5f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable resource = other.transform.root.GetComponent<Collectable>();

        //if touching something that can be added to inventory
        if (resource)
        {
            foreach (InventorySlot slot in slots)
            {
                //if matching item is found in inventory, add it to stack
                if (slot.itemName == resource.resource.itemName)
                {
                    slot.count++;
                    break;
                }
                //create new stack if now stack is found
                else if (slot.itemName == "")
                {
                    slot.itemName = resource.resource.itemName;
                    slot.count = 1;
                    slot.SetSprite(resource.resource.inventorySprite);
                    break;
                }
            }
            Destroy(other.transform.root.gameObject);
        }
    }

    public static bool Build(BuildButton.Requirement[] requirements)
    {

        if (!CanItBuild(requirements))
            return false;

        foreach (BuildButton.Requirement req in requirements)
        {
            foreach (InventorySlot slot in slots_s)
            {
                if (slot.itemName == req.item.itemName && slot.count >= req.amountRequired)
                {
                    slot.count -= req.amountRequired;
                }

            }
        }

        return true;
    }

    public static bool CanItBuild(BuildButton.Requirement[] requirements)
    {
        bool canBeDone = false;

        //check if there are enough resources
        foreach (BuildButton.Requirement req in requirements)
        {
            bool reqMet = false;
            //once at least one resource requirement is not met, return
            foreach (InventorySlot slot in slots_s)
            {
                if (slot.itemName == req.item.itemName && slot.count >= req.amountRequired)
                {
                    reqMet = true;
                }

            }

            canBeDone = reqMet;
            if (!canBeDone)
                return false;
        }
        return true;
    }

    public static void RegainResources(BuildButton.Requirement[] requirements)
    {
        foreach (BuildButton.Requirement req in requirements)
        {
            foreach (InventorySlot slot in slots_s)
            {
                if (slot.itemName == req.item.itemName)
                {
                    slot.count += req.amountRequired;
                }

            }
        }
    }
}
