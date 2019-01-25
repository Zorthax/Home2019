using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<InventorySlot> slots = new List<InventorySlot>();
    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 6))
            {
                BreakableResource thing = hit.transform.root.GetComponent<BreakableResource>();
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

        if (resource)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.itemName == resource.resource.itemName)
                {
                    slot.count++;
                    break;
                }
                else if (slot.itemName == "")
                {
                    slot.itemName = resource.resource.itemName;
                    slot.count = 1;
                    slot.SetSprite(resource.resource.inventorySprite);
                    break;
                }
            }
            Destroy(other.gameObject);
        }
    }
}
