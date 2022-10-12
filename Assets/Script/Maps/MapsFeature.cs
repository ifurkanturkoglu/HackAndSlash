using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsFeature : MonoBehaviour
{
    [SerializeField]
    MapsType mapsFeature;

    float instantiateMapTime,enemySpawnTime;

    void Start()
    {
        instantiateMapTime = mapsFeature.instantiateGameTime;
        enemySpawnTime = mapsFeature.enemySpawnTime;
    }

}
