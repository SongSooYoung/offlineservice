using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // �÷��̾� �ֺ��� 
    // ������ ������ ���� ������ ���ظ� �ְ� ������� �ʹ�.
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