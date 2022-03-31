using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Collider>().enabled = false;
        Invoke("ShowCollider", 0.1f);
    }

    void ShowCollider()
    {
        GetComponent<Collider>().enabled = true;

    }

    public int value;

    private void Update()
    {
        transform.Rotate(Vector3.up * 30 * Time.deltaTime);
    }
}
