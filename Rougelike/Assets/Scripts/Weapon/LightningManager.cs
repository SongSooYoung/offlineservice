using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//범위 세로 50 가로 60
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

        // 키입력을 쿨타임지났을떄로 바꾼다.
        if( cols.Length > 0 && cooltime > 1 ) {
           // 번개 발생. 
           int randomNum = Random.Range(0, cols.Length);

            cooltime = 0;
           // 디스트로이를 데미지로 바꾼다.

        // HitDamage( 상대 , 데미지);
       
        
           GameObject lightning =Instantiate(lightningFactory);
            lightning.transform.position = cols[randomNum].gameObject.transform.position;
        }
        
        // while(rValue > cols.Length)
        // {
        //     rValue = Random.Range(0,cols.Length);
        // }
        
        // if (rValue < cols.Length && cols[rValue].CompareTag("Enemy") && cooltime > 1)
        // {
        //   print("lighting");
        //   Destroy(cols[rValue].gameObject);
        //   cooltime = 0;
        // }   
        
    }

}


