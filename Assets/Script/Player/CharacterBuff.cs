using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuff : MonoBehaviour
{
    [SerializeField] GameObject[] buff;
    [SerializeField] GameObject buffSpawnPosition;
    playerMove playerMove;
    void Start()
    {
        InvokeRepeating("BuffSpawn",0,60);
        playerMove = FindObjectOfType<playerMove>();
    }

    void BuffSpawn(){
        float spawnX = Random.Range(-100,100);
        float spawnZ = Random.Range(-100,100);
        int rand  = Random.Range(0,buff.Length);
        Vector3 spawnPos = new Vector3(buffSpawnPosition.transform.position.x+spawnX,buffSpawnPosition.transform.position.y,buffSpawnPosition.transform.position.z+spawnZ);
        GameObject buffClone = Instantiate(buff[rand],spawnPos,buff[rand].transform.rotation);
        buffClone.transform.SetParent(gameObject.transform);
        buffClone.transform.name = buffClone.transform.name.Replace("(Clone)","");
    }

    public void buffActiveded(string buffName){
        switch (buffName)
        {
            case "Heal":
                Heal();
                break;
            case "Movement":
                Movement();
                break;
        }
        print(playerMove.playerHealth);
        
    }

    public void Heal(){
        if(playerMove.playerHealth <=playerMove.playerMaxHealth -30)
            playerMove.playerHealth += 30;
        else{
            playerMove.playerHealth += Mathf.Abs(playerMove.playerMaxHealth - playerMove.playerHealth);
        }    
        print(playerMove.playerHealth);
    }
    public void Movement(){
        playerMove.speed += 10;
    }
}
