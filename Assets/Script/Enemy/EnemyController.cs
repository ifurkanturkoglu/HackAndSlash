using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject target;

    [SerializeField]EnemyType enemyType;

    public float health;
    [HideInInspector] public int score;
    GameObject deadEffect;
    [HideInInspector] public int damage;
   
   
   void Start()
   {
        target = GameObject.Find("Player");
        health = enemyType.health;
        score = enemyType.score;
        damage = enemyType.damage;
        deadEffect = enemyType.deadEffect;
   }
    void Update()
    {
        if(target)
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,10*Time.deltaTime);
        if(health <=0){
            FindObjectOfType<ScoreManager>().score += score;
            Instantiate(deadEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        };
    }

    //TODO Düşman çarpışmasına bakılacak. Çok hızlı vuruyor.
    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.name.Equals("Player")){
            FindObjectOfType<playerMove>().playerHealth -= damage;
        }    
        else if(other.gameObject.tag.Equals("skill")){
            FindObjectOfType<playerMove>().playerHealth -= FindObjectOfType<InventoryController>().skillDamage;
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("bullet")){
            StartCoroutine(takeDamageEnemy());
        }
    }
    
    IEnumerator takeDamageEnemy(){
        gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.white);
    }

    void OnParticleCollision(GameObject other)
    {
        health -= FindObjectOfType<InventoryController>().skillDamage;
        Destroy(gameObject,0.1f);
    }

}
