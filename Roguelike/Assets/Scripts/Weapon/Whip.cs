using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Whip : MonoBehaviour
{

    //  ������ ����ʹ�.  
    //  ������ �������� �ְ� �ʹ�
    //  ���� ������ �����ϸ� ������� �ʹ�.   !
    public float speed = 100f;

    Vector3 dir;
    bool bIsCollisionEnter;
    void Start()
    {
        Destroy(gameObject, 0.20f);
    }
    void Update()
    {
        // �� �������� ����.
        transform.position += transform.forward * speed * Time.deltaTime;
        //Vector3 �� �ϸ� �۷ι� �������� ������ Ʈ�������� ���� �������� 
        // ������ �Ÿ��� ����
        // ������� �ʹ�.

    }
}