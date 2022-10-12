using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject bulletSpawn, bullets;
    bool isFire;

    [HideInInspector] public int bulletDamage = 25;

    void Start()
    {
        StartCoroutine(nameof(Fire));
    }

    void Update()
    {
        isFire = Input.GetMouseButton(0) ? true: false;
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if(isFire){
                GameObject bulletCopy = Instantiate(bullets, bulletSpawn.transform.position, Quaternion.Euler(-90, 0, 0));
                bulletCopy.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * 50f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
