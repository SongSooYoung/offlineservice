using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    public Transform target;
    public float orbitspeed = 0;


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, orbitspeed * Time.deltaTime);
    }

}
