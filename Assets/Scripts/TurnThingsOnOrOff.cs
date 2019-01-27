using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnThingsOnOrOff : MonoBehaviour {

    public GameObject[] turnOff;
    public GameObject[] turnOn;
    public string inputButton;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inputButton != "" && Input.GetButtonDown(inputButton))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Activate();
        }
	}

    public void Activate()
    {
        foreach (GameObject obj in turnOn)
            obj.SetActive(true);
        foreach (GameObject obj in turnOff)
            obj.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
