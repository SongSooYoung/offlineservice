using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //�ε��� ��븦 �ı��ϰڴ�
        Destroy(other.gameObject);
    }
}
