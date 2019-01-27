using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnE : MonoBehaviour {

    public Vector3[] rotations;
    public float rotationSpeed = 10;
    int index = 0;
    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotations[index]), rotationSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 9))
        {
            if (hit.transform == transform)
            {
                KeyPrompts.StartPrompt(KeyPrompts.Prompt.E);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    index++;
                    if (index >= rotations.Length)
                        index = 0;
                }
            }
            else
            {
                KeyPrompts.EndPrompt(KeyPrompts.Prompt.E);
            }
        }
        else
        {
            KeyPrompts.EndPrompt(KeyPrompts.Prompt.E);
        }

    }
}
