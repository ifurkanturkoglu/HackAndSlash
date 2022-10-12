using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="Default Type",menuName = "EnemyTypeCreate")]
public class EnemyType : ScriptableObject
{
    public float health;
    public float speed;
    public int score;
    public int damage;
    public GameObject deadEffect;

}
