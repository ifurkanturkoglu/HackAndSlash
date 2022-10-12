using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    InventoryController inventoryController;
    public GameObject inventoryItemPrefab,inventoryUI;
    void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();
        inventoryUI = inventoryController.inventoryUI;
    }

    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name.Equals("Player") && inventoryController.inventory.Count < 4){
            InventoryController.InventoryItems inventoryItem = new InventoryController.InventoryItems();
            inventoryItem.itemsName = gameObject.name;
            inventoryItem.skill = gameObject;
            inventoryItem.skillImage = gameObject.GetComponent<Image>();
            inventoryController.inventory.Add(inventoryItem);
            inventoryItemPrefab.GetComponent<Image>().sprite = inventoryItem.skillImage.sprite;
            Instantiate(inventoryItemPrefab,inventoryUI.transform);
            gameObject.SetActive(false);
        }
    }
}
