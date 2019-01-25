using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {


    public string itemName = "";
    public int count = 0;
    public Image itemImage;
    public Text countUi;

    // Use this for initialization
    void Start ()
    {

	}
    void Update()
    {
        countUi.transform.parent.gameObject.SetActive(itemName != "");
        countUi.text = count.ToString();
    }
	
	public void SetSprite (Sprite sprite)
    {
        itemImage.sprite = sprite;
	}
}
