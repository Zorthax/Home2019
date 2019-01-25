﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTile : MonoBehaviour {

    MeshRenderer mesh;
    Camera cam;
    GeneralCommands buildStuff;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshRenderer>();
        cam = Camera.main;
        buildStuff = FindObjectOfType<GeneralCommands>();

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
            }
        }
        if (on)
        {
            mesh.enabled = true;
            KeyPrompts.StartPrompt(KeyPrompts.Prompt.Left_Mouse);
            if (Input.GetMouseButtonDown(0))
            {
                buildStuff.OpenBuildMenu(transform);

            }
        }
        else
        {
            mesh.enabled = false;
            KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
        }
    }

}
