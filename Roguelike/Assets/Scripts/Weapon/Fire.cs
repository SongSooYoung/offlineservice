using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // �÷��̾� �ֺ��� 
    // ������ ������ ���� ������ ���ظ� �ְ� ������� �ʹ�.
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
