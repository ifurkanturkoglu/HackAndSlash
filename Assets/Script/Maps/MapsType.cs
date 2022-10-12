using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="DefaultMap",menuName = "MapsType")]
public class MapsType : ScriptableObject
{
    public float instantiateGameTime,enemySpawnTime;
    public GameObject maps;
}