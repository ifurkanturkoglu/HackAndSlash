using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMap : MonoBehaviour
{

    [SerializeField] GameObject[] Maps;
    [SerializeField] GameObject[] MapsPoint;
    [SerializeField] GameObject stair, stairStartPosition,chest;
    UIController uiController;
    EnemySpawn enemySpawn;
    public GameObject currentMap;
    int mapsQueue = 0;

    [HideInInspector] public bool isMapNext, IsChestOpen;


    void Start()
    {
        uiController = FindObjectOfType<UIController>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        InvokeRepeating(nameof(mapsCreateWait), 0, 1);
    }
    void mapsCreateWait()
    {
        if (uiController.game_time % 7 == 0 && uiController.game_time != 0 && !IsChestOpen)
        {
            chest.SetActive(true);
            isMapNext = false;
            //timer durdurulacak.++
            enemySpawn.EnemySpawnInvokeChange(false);
            //düşman spawn kesilecek.
            //spawn konumu currentMape aktarılacak.
            
        }
        else if (IsChestOpen)
        {
            uiController.chestUI.SetActive(true);
            Time.timeScale = 0;
            IsChestOpen = false;
            mapsQueue++;            
            CreateNewMap();
            StartCoroutine(nameof(stairLoad));
        }
    }

    IEnumerator stairLoad()
    {
        Vector3 right = new Vector3(-5, 0, 0);
        for (int i = 0; i < 15; i++)
        {
            GameObject stairClone = Instantiate(stair, stairStartPosition.transform.position, Quaternion.identity);
            stairClone.transform.SetParent(MapsPoint[mapsQueue].transform);
            stairStartPosition.transform.position += right;
            yield return new WaitForSeconds(0.7f);
        }
    }
    void CreateNewMap()
    {
        print(mapsQueue);
        GameObject newMap = Instantiate(Maps[mapsQueue], MapsPoint[mapsQueue].transform.position, Quaternion.identity);
        newMap.transform.SetParent(MapsPoint[mapsQueue].transform);
        newMap.name = newMap.name.Replace("(Clone)","");
        currentMap = newMap;
    }

    public void mapChangeUpdate(){
        isMapNext = true;
        chest.transform.position = currentMap.transform.position;
        chest.SetActive(false);
        enemySpawn.gameObject.transform.position = currentMap.transform.position;
        enemySpawn.EnemySpawnInvokeChange(true);
    }
}
