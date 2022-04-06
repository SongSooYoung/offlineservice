using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    public Transform target;
    public float orbitspeed;
    Vector3 offset;
    Player player;
    bool bIsCollisionEnter;
    void Start()
    {

        this.player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            offset = transform.position - player.transform.position;
        }

    }
    float speed = 400f;

    void Update()
    {
        if (this.player != null)
        {
            transform.position = player.transform.position + offset;

            transform.RotateAround(player.transform.position, Vector3.up, orbitspeed * Time.deltaTime);

            offset = transform.position - player.transform.position;
        }
    }
}