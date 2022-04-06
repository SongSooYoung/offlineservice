using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    //���� ��ǥ�� ��ġ �������� public ������ ���� 
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = target.position + offset;
        }
    }
}
