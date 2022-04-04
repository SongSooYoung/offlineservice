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
            print("HPÈ¹µæ : 1");
            Destroy(gameObject);
            //ÀÚ±â ÀÚ½ÅÀ» ÆÄ±«


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
