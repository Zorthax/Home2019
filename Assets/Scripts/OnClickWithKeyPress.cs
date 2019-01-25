using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickWithKeyPress : MonoBehaviour {

    Button button;
    public KeyCode key;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(key))
            button.onClick.Invoke();
	}
}
