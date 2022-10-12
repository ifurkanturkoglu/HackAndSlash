using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    

    public List<InventoryItems> inventory = new List<InventoryItems>(4);
    public GameObject inventoryUI;
    public GameObject []items;
    GameObject frostClone;
    bullet bullet;

    float started_frost_x,started_frost_z,frost_time;
    public int skillDamage = 100;
    playerMove playerMove;

    InventoryItem inventoryItem;


    [System.Serializable]
    public struct InventoryItems{
        public GameObject skill;
        public Image skillImage;
        public string itemsName;
    }

    void Start()
    {
        bullet = FindObjectOfType<bullet>();
        playerMove = FindObjectOfType<playerMove>();
        inventoryItem = FindObjectOfType<InventoryItem>();
        
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Z)){
        //     ChangeAbility();
        // }
        //TODO frost skiline bakılacak. Takip etmede sıkıntı var.
        if(frostClone){
            frostClone.transform.RotateAround(playerMove.transform.position,Vector3.up,360*Time.deltaTime);
            frost_time += Time.deltaTime;
            if(frost_time >= 60)Destroy(frostClone);
        }
    }

    // void ChangeAbility(){
    //     if(inventory.Count >= 2){
    //         print(inventory.Count);
    //         InventoryItems a = inventory[0];
    //         inventory[0] = inventory[inventory.Count-1];
    //         for (int i = 1; i < inventory.Count; i++)
    //         {  
    //             inventory[i] = inventory[i-1];
    //         }
    //     }
    // }

    public void useAbility(){
        switch(inventory[0].itemsName){
            case "Fireball":
                Fireball(items[0]);
                break;
            case "Frost":
                Frost(items[1]);
                break;    
        }
        inventory.RemoveAt(0);
        Destroy(inventoryUI.transform.GetChild(0).gameObject);
    }

    void Fireball(GameObject g){
        skillDamage = 200;
        GameObject fireballClone = Instantiate(g,bullet.bulletSpawn.transform.position,Quaternion.identity);
        fireballClone.GetComponent<Rigidbody>().velocity = bullet.bulletSpawn.transform.forward * 65f;
        Destroy(fireballClone,5);
    }

    void Frost(GameObject g){
        skillDamage = 300;
        frostClone = Instantiate(g,playerMove.gameObject.transform.position,Quaternion.identity);
    }
}
