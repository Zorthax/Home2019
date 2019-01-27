using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GeneralCommands : MonoBehaviour {

    public GameObject buildMenu;
    public RigidbodyFirstPersonController fps;
    public static BuildingTile buildTile;
    Camera cam;


	// Use this for initialization
	void Start () {
        CloseBuildMenu();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (buildTile)
        {
            buildTile.scaleOffset += Input.GetAxis("Mouse ScrollWheel") * 4 * Time.deltaTime;
            buildTile.positionOffset += cam.transform.root.right * Input.GetAxis("Horizontal") * 4 * Time.deltaTime;
            buildTile.positionOffset += cam.transform.root.forward * Input.GetAxis("Vertical") * 4 * Time.deltaTime;

            buildTile.scaleOffset = Mathf.Clamp(buildTile.scaleOffset, 0.7f, 1.3f);
            buildTile.positionOffset.x = Mathf.Clamp(buildTile.positionOffset.x, -1f, 1f);
            buildTile.positionOffset.z = Mathf.Clamp(buildTile.positionOffset.z, -1f, 1f);
        }
	}

    public void OpenBuildMenu(Transform tile)
    {
        buildMenu.SetActive(true);
        fps.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        buildTile = tile.GetComponent<BuildingTile>();
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
        buildTile.requirements = buildButton.requirements;
        buildTile.placedObject = Instantiate(buildButton.thingToBuild, buildTile.transform.position, buildTile.transform.rotation) as GameObject;
        buildTile.placedObject.transform.localScale *= buildTile.scaleOffset;
        buildTile.placedObject.transform.position += buildTile.positionOffset;
        CloseBuildMenu();
        KeyPrompts.EndPrompt(KeyPrompts.Prompt.Left_Mouse);
    }

    public void RotateTile(float angle)
    {
        buildTile.transform.Rotate(new Vector3(0, angle, 0));
    }

}
