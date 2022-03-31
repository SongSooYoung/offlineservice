using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Whip : MonoBehaviour
{

    //  앞으로 가고싶다.  
    //  적에게 데미지를 주고 싶다
    //  일정 범위에 도착하면 사라지고 싶다.   !
    public float speed = 100f;

    Vector3 dir;
    bool bIsCollisionEnter;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.20f);
    }
    // Update is called once per frame
    void Update()
    {
        // 그 방향으로 간다.
        transform.position += transform.forward * speed * Time.deltaTime;
        //Vector3 로 하면 글로벌 방향으로 나가고 트랜스폼은 로컬 방향으로 
        // 일정한 거리를 가면
        // 사라지고 싶다.

    }
}