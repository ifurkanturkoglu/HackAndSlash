using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] GameObject spawnPosition;
    public int enemySpawnTime = 1;

    
    
    void EnemiesSpawn(){
        float spawnX = Random.Range(-100,100);
        float spawnZ = Random.Range(-100,100);
        int rand  = Random.Range(0,enemy.Length);
        Vector3 spawnPos = new Vector3(spawnPosition.transform.position.x+spawnX,spawnPosition.transform.position.y,spawnPosition.transform.position.z+spawnZ);
        Instantiate(enemy[rand],spawnPos,Quaternion.identity);
    }

    public void EnemySpawnInvokeChange(bool b){
        if(b)InvokeRepeating(nameof(EnemiesSpawn),0,enemySpawnTime);
        else CancelInvoke(nameof(EnemiesSpawn));
    }
}
