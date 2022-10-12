using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
   Vector3 startTransform;
    void Start()
    {
        Vector3 stairUp = new Vector3(0, 51.9f, 0);
        startTransform = transform.position;
        startTransform += stairUp; 
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,startTransform,Time.deltaTime);
    }
}
