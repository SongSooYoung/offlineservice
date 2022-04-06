using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 생성되는 순간에 가장 가까웠던 적이 있는 방향으로 가고 싶다.
public class Magic : MonoBehaviour
{

    public float speed = 1f;
    GameObject[] enemys;
    GameObject minDistEnemy;
    GameObject target;
    float minVal = 99999;
    float Distance;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어와 적과의 거리의 숫자가 최솟값인 친구에게

        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        // 배열접근은 인덱스로 접근을 하는데 [인덱스]
        for (int i = 0; i < enemys.Length; i++)
        {
            Distance = Vector3.Distance(transform.position, enemys[i].transform.position);

            if (minVal > Distance)
            {
                minVal = Distance;
                minDistEnemy = enemys[i];
            }
        }
        if (minDistEnemy)
        {
            transform.LookAt(minDistEnemy.transform);
        }
        // for whim 꼭 알아둘 것
    }
    void Update()

    //방향으로 가고 싶다.
    {
        Vector3 dir = transform.forward;

        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}