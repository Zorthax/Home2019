using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GeneralCommands : MonoBehaviour {

    public GameObject buildMenu;
    public RigidbodyFirstPersonController fps;
    Transform buildTile;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenBuildMenu(Transform tile)
    {
        buildMenu.SetActive(true);
        fps.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        buildTile = tile;
    }

    public void CloseBuildMenu()
    {
        buildMenu.SetActive(false);
        fps.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BuildThing(GameObject whatToBuild)
    {
        Instantiate(whatToBuild, buildTile.position, buildTile.rotation);
        Destroy(buildTile.gameObject);
        CloseBuildMenu();
        KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
    }
}
