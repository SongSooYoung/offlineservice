using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//EXP프리팹에 대한 정보
//
public class EXP : MonoBehaviour
{
    GameObject Player;
    Vector3 dir;
    public float acceleration = 1;
    float velocity;
    public float expDistance = 15f;
    void Start()
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
        Player = GameObject.Find("Player");
        transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        CoinMove();
    }

    public void CoinMove()
    {
        dir = (Player.transform.position - transform.position).normalized;
        velocity = (velocity + acceleration * Time.deltaTime);
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance <= expDistance)

        {
            transform.position = new Vector3(transform.position.x + (dir.x * velocity), transform.position.y, transform.position.z + (dir.z * velocity));
        }
        else
        {
            velocity = 0.0f;
        }

    }

}
