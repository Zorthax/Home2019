using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<InventorySlot> slots = new List<InventorySlot>();
    Camera cam;

    static List<InventorySlot> slots_s;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        slots_s = slots;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 6))
            {
                //if hitting a breakable like a tree or rock
                BreakableResource thing = hit.transform.GetComponentInParent<BreakableResource>();
                if (thing)
                {
                    thing.TakeDamage(1);
                }
            }
        }
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
