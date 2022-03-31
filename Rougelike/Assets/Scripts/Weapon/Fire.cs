using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // 플레이어 주변에 
    // 적에게 닿으면 일정 범위에 피해를 주고 사라지고 싶다.
    public float speed = 10f;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
