using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    //에너미의 속도
    public float speed = 5f;
    //에너미의 타겟을 선언
    private GameObject target;
    NavMeshAgent agent;
    //HP Class를 이용한 에너미의 체력
    ALLHP ehp;

    void Start()
    {
        //에너미가 베이크 한 곳에서 찾을 수 있게끔.
        agent = GetComponent<NavMeshAgent>();
        //에너미의 체력스크립트를 가져와준다.
        ehp = gameObject.GetComponent<ALLHP>();
    }

    void Update()
    {
        //게임상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if (GameManager.instance.gState != GameManager.GameState.Run)
        {
            return;
        }
        //게임오브젝트 중 플레이어를 찾아 타겟으로 지정해준다.
        GameObject target = GameObject.Find("Player");
        if (target) //만약 타겟이라면 내가 계속해서 찾아갈 곳은 타겟의 위치이다.
        {
            agent.destination = target.transform.position;
        }
    }
    // EXPLOSION 선언
    public GameObject explosionFactory;
    // EXP 선언
    public GameObject expFactory;
    // HP Potion 선언
    public GameObject hpPotionFactory;

    //에너미에게 입히는 데미지
    public void TryDamage(float damageVelue)
    {

        //에너미의 체력에서 받은 데미지값을 빼준다.
        ehp.HP -= damageVelue;
        //만약 에너미의 체력이 0보다 작거나 0이 되었을 때는 에너미는 죽는다.
        if (ehp.HP <= 0)
        {
            SpawnManager.instance.creatCount--;
            Destroy(gameObject);
        }
    }

    //OnTriggerEnter 충돌 후 수학적인 계산 수행 안함
 
    //OnCollisionEnter 충돌 후 반사 등의 수학적인 계산 수행
    private void OnTriggerEnter(Collider other)
    {
        //에너미가 다른 무언가와 부딪혔을 때 효과가 발생된다.
        GameObject fx = Instantiate(explosionFactory);
        fx.transform.position = transform.position;
        Destroy(fx, 3); //3초 뒤에 삭제

        //만약 에너미와 부딪힌 상대가 Weapon 태그를 붙힌 상대라면
        if (other.gameObject.CompareTag("Weapon"))
        {
            
                //Weaponinfo cs 에서 #이해안됨#
                WeaponInfo info = other.gameObject.GetComponent<WeaponInfo>();
            float damage = DamageManager.instance.GetDamage(info.type);

            TryDamage(damage);

        }
        //또는 에너미와 부딪힌  상대가 Player 태그를 붙힌 상대라면
        else if (other.gameObject.CompareTag("Player"))
        {
            //ALLHP.CS가 가진 기능을 가져와주고 php 변수로 선언해준다.
            ALLHP php = other.gameObject.GetComponent<ALLHP>();
            //플레이어어 HP에서 HP를 감소시켜준다.
            php.HP--;
            //히트매니저의 히트를 실행시켜준다.
            HitManager.instance.DoHitPlz();
            //만약 Player.HP가 0이되면
            if (php.HP <= 0)
            {
                //부딪힌 플레이어는 죽고
                Destroy(other.gameObject);
                //GameManager.정보를 불러오다.gameOverUI를 켜준다
                GameManager.instance.gameOverUI.SetActive(true);
                //게임 시간을 멈춘다.
                Time.timeScale = 0f;
                //게임 상태를 GameOver 상태로 돌려준다.
                GameManager.instance.gState = GameManager.GameState.GameOver;
            }
            TryDamage(1); // 에너미가 플레이어와 부딪혔을 시 
        }
       
        //에너미의 체력이 0이라면
        if (ehp.HP <= 0)
        {
            //exp 잼을 생성해준다. 에너미가 죽은 위치에 +1
            GameObject exp = Instantiate(expFactory);
            exp.transform.position = transform.position;
            // 랜덤 5/100의 확률로 HP포션이 생성됨.
            int rValue = Random.Range(0, 100);
            if (rValue < 5)
            {
                GameObject hpPotion = Instantiate(hpPotionFactory);
                hpPotion.transform.position = transform.position;
            }
            //ScoreManager를 불러와 SCORE 점수를 적립해준다.
            ScoreManager.instance.SCORE++;
        }
        /* if (collision.gameObject.CompareTag("Bible"))
         {
             WeaponInfo info = collision.gameObject.GetComponent<WeaponInfo>();
             float damage = DamageManager.instance.GetDamage(info.type);
             //데미지 처리를 하고 
             //파괴는 안시킨다. 
             TryDamage(damage);
         }
         else
         {
         }*/



    }

}
