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
    Button button;

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
        foreach (Requirement req in requirements)
        {
            tooltipText.text += req.item.itemName + " x" + req.amountRequired.ToString();
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

	}

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }
    public void Build()
    {
        Inventory.Build(requirements);
    }
}
