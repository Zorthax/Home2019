using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;
    public GameObject thingToBuild;
    public Requirement[] requirements;
    public GameObject tooltip;
    public Text tooltipText;
    public Material transparentMaterial;
    Button button;
    GameObject ghostObject;

    [System.Serializable]
    public class Requirement
    {
        public Resource item;
        public int amountRequired;
    }

    // Use this for initialization
    void Start ()
    {
        tooltipText.text = "Requires: ";
        int i = 0;
        foreach (Requirement req in requirements)
        {
            if (i > 0)
                tooltipText.text += ", ";
            tooltipText.text += req.item.itemName + " x" + req.amountRequired.ToString();
            i++;
        }
        button = GetComponent<Button>();
	}
	
    void OnEnable()
    {
        isOver = false;
    }

	// Update is called once per frame
	void Update ()
    {
        tooltip.SetActive(isOver);
        button.interactable = Inventory.CanItBuild(requirements);
        if (ghostObject)
            ghostObject.transform.rotation = GeneralCommands.buildTile.rotation;

    }

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        ghostObject  = Instantiate(thingToBuild, GeneralCommands.buildTile.position, GeneralCommands.buildTile.rotation) as GameObject;
        foreach (Renderer rend in ghostObject.GetComponentsInChildren<Renderer>())
            rend.material = transparentMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        if (ghostObject)
            Destroy(ghostObject);
    }
    public void Build()
    {
        Inventory.Build(requirements);
        if (ghostObject)
            Destroy(ghostObject);
    }
}
