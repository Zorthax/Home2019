using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickWithKeyPress : MonoBehaviour {

    Button button;
    public string buttonName;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown(buttonName))
            button.onClick.Invoke();
	}
}
