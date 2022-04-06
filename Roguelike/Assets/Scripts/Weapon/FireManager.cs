using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public Transform target;
    public float orbitspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, orbitspeed * Time.deltaTime);

    }
}
