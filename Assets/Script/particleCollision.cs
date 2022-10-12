using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleCollision : MonoBehaviour
{

    void Start()
    {
        print(gameObject.name);
    }
    void OnParticleCollision(GameObject other)
    {
        FindObjectOfType<EnemyController>().health -= FindObjectOfType<InventoryController>().skillDamage;
        if(other.gameObject.name !="Frost")
            Destroy(gameObject);
        print("ss");    
    }
}
