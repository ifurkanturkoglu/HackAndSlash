using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInventoryItem : MonoBehaviour
{
    
    [SerializeField] GameObject ItemSpawnPosition,itemStored;
    [SerializeField] GameObject []Items;
    void Start()
    {
        InvokeRepeating(nameof(spawnItem),0,30);
    }

    void spawnItem(){
        float spawnX = Random.Range(-100,100);
        float spawnZ = Random.Range(-100,100);
        int rand  = Random.Range(0,Items.Length);
        Vector3 spawnPos = new Vector3(ItemSpawnPosition.transform.position.x+spawnX,ItemSpawnPosition.transform.position.y,ItemSpawnPosition.transform.position.z+spawnZ);
        GameObject item = Instantiate(Items[rand],spawnPos,Quaternion.identity);
        item.transform.name = item.transform.name.Replace("(Clone)","");
        item.transform.SetParent(itemStored.transform);
        
    }
}
