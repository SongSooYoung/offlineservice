using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KnifePosition : MonoBehaviour
{

    public float createTime = 0;


    float currentTime;


    public GameObject weaponFactory;

    public GameObject weaponPosition;
    void Start()
    {

    }


    void Update()
    {

        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject knife = Instantiate(weaponFactory);
            knife.transform.position = weaponPosition.transform.position;

            currentTime = 0;
            transform.LookAt(transform.position);

            knife.transform.forward = transform.forward;
        }

    }
}