using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    public Transform target;
    public float orbitspeed;
    Vector3 offset;
    bool bIsCollisionEnter;
    void Start()
    {
        offset = transform.position - target.position;
    }
    float speed = 400f;

    void Update()
    {
        transform.position = target.position + offset;

        transform.RotateAround(target.position, Vector3.up, orbitspeed * Time.deltaTime);

        offset = transform.position - target.position;
    }
}