using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GeneralCommands : MonoBehaviour {

    public GameObject buildMenu;
    public RigidbodyFirstPersonController fps;
    public static Transform buildTile;


	// Use this for initialization
	void Start () {
        CloseBuildMenu();
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

    public void BuildThing(BuildButton buildButton)
    {
        //Destroy(buildTile.gameObject);
        Debug.Log("Did it build?");
        buildTile.GetComponent<BuildingTile>().requirements = buildButton.requirements;
        buildTile.GetComponent<BuildingTile>().placedObject = Instantiate(buildButton.thingToBuild, buildTile.position, buildTile.rotation) as GameObject;
        CloseBuildMenu();
        KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
    }

    public void RotateTile(float angle)
    {
        buildTile.Rotate(new Vector3(0, angle, 0));
    }
}
