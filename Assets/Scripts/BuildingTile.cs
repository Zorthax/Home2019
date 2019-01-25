using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTile : MonoBehaviour {

    MeshRenderer mesh;
    Camera cam;
    GeneralCommands buildStuff;
    static BuildingTile lastTileLookedAt;
    [HideInInspector]
    public GameObject placedObject;
    [HideInInspector]
    public BuildButton.Requirement[] requirements;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshRenderer>();
        cam = Camera.main;
        buildStuff = FindObjectOfType<GeneralCommands>();
        //KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
    }

    // Update is called once per frame
    void Update()
    {
        bool on = false;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 9))
        {
            if (hit.transform == transform)
            {
                on = true;
                lastTileLookedAt = this;
            }
        }
        if (on)
        {
            mesh.enabled = true;
            if (placedObject == null)
            {
                KeyPrompts.StartPrompt(KeyPrompts.Prompt.Left_Mouse);
                if (Input.GetMouseButtonDown(0))
                {
                    buildStuff.OpenBuildMenu(transform);

                }
            }
            else
            {
                KeyPrompts.StartPrompt(KeyPrompts.Prompt.Right_Mouse);
                if (Input.GetMouseButtonDown(1))
                {
                    Inventory.RegainResources(requirements);
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Right_Mouse);
                    Destroy(placedObject);
                }
            }

            
        }
        else
        {
            mesh.enabled = false;
            if (lastTileLookedAt == this)
            {
                if (placedObject == null)
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
                else
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Right_Mouse);
            }
        }
    }

}
