using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPotion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject playerGameObject = other.gameObject;

            ALLHP playerAllHp = playerGameObject.GetComponent<ALLHP>();

            playerAllHp.HP++;
            print("HPȹ�� : 1");
            Destroy(gameObject);
            //�ڱ� �ڽ��� �ı�


        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
