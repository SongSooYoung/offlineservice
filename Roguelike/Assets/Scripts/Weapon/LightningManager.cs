using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightningManager : MonoBehaviour
{
    
    public GameObject lightningFactory;
    
   int rValue;
    GameObject[] enemys;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
    rValue = Random.Range(0,10);
    
    }

 float cooltime;
    // Update is called once per frame
    void Update()
    {
         cooltime += Time.deltaTime;
        Collider[] cols = Physics.OverlapSphere(transform.position, 40 , enemyLayer) ;

        if( cols.Length > 0 && cooltime > 1 ) {
           // 번개 발생. 
           int randomNum = Random.Range(0, cols.Length);
            cooltime = 0;
           GameObject lightning =Instantiate(lightningFactory);
            lightning.transform.position = cols[randomNum].gameObject.transform.position;
        }
        
    }

}


