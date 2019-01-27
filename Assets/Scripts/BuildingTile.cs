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
    [HideInInspector]
    public float scaleOffset = 1;
    [HideInInspector]
    public Vector3 positionOffset = Vector3.zero;

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
                if (Input.GetButtonDown("Fire1"))
                {
                    buildStuff.OpenBuildMenu(transform);

                }
            }
            else
            {
                KeyPrompts.StartPrompt(KeyPrompts.Prompt.Right_Mouse);
                if (Input.GetButtonDown("Fire2"))
                {
                    Inventory.RegainResources(requirements);
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Right_Mouse);
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
                    Destroy(placedObject);
                }
            }

            
        }
        else
        {
            mesh.enabled = false;
            if (lastTileLookedAt == this)
            {
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
                    KeyPrompts.EndPrompt(KeyPrompts.Prompt.Right_Mouse);
            }
        }
    }

}
