using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("Enemy")){
            other.gameObject.GetComponent<EnemyController>().health -= FindObjectOfType<bullet>().bulletDamage;
        }
        Destroy(gameObject);
    }
}
