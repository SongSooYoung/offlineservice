using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // 플레이어 주변에 
    // 적에게 닿으면 일정 범위에 피해를 주고 사라지고 싶다.
    public float speed = 10f;
    Vector3 dir;
    void Start()
    {
        

    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
