using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    //���ʹ��� �ӵ�
    public float speed = 5f;
    //���ʹ��� Ÿ���� ����
    private GameObject target;
    NavMeshAgent agent;
    //HP Class�� �̿��� ���ʹ��� ü��
    ALLHP ehp;

    void Start()
    {
        //���ʹ̰� ����ũ �� ������ ã�� �� �ְԲ�.
        agent = GetComponent<NavMeshAgent>();
        //���ʹ��� ü�½�ũ��Ʈ�� �������ش�.
        ehp = gameObject.GetComponent<ALLHP>();
    }

    void Update()
    {
        //���ӻ��°� '���� ��' ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.instance.gState != GameManager.GameState.Run)
        {
            return;
        }
        //���ӿ�����Ʈ �� �÷��̾ ã�� Ÿ������ �������ش�.
        GameObject target = GameObject.Find("Player");
        if (target) //���� Ÿ���̶�� ���� ����ؼ� ã�ư� ���� Ÿ���� ��ġ�̴�.
        {
            agent.destination = target.transform.position;
        }
    }
    // EXPLOSION ����
    public GameObject explosionFactory;
    // EXP ����
    public GameObject expFactory;
    // HP Potion ����
    public GameObject hpPotionFactory;

    //���ʹ̿��� ������ ������
    public void TryDamage(float damageVelue)
    {

        //���ʹ��� ü�¿��� ���� ���������� ���ش�.
        ehp.HP -= damageVelue;
        //���� ���ʹ��� ü���� 0���� �۰ų� 0�� �Ǿ��� ���� ���ʹ̴� �״´�.
        if (ehp.HP <= 0)
        {
            SpawnManager.instance.creatCount--;
            Destroy(gameObject);
        }
    }

    //OnTriggerEnter �浹 �� �������� ��� ���� ����
 
    //OnCollisionEnter �浹 �� �ݻ� ���� �������� ��� ����
    private void OnTriggerEnter(Collider other)
    {
        //���ʹ̰� �ٸ� ���𰡿� �ε����� �� ȿ���� �߻��ȴ�.
        GameObject fx = Instantiate(explosionFactory);
        fx.transform.position = transform.position;
        Destroy(fx, 3); //3�� �ڿ� ����

        //���� ���ʹ̿� �ε��� ��밡 Weapon �±׸� ���� �����
        if (other.gameObject.CompareTag("Weapon"))
        {
            
                //Weaponinfo cs ���� #���ؾȵ�#
                WeaponInfo info = other.gameObject.GetComponent<WeaponInfo>();
            float damage = DamageManager.instance.GetDamage(info.type);

            TryDamage(damage);

        }
        //�Ǵ� ���ʹ̿� �ε���  ��밡 Player �±׸� ���� �����
        else if (other.gameObject.CompareTag("Player"))
        {
            //ALLHP.CS�� ���� ����� �������ְ� php ������ �������ش�.
            ALLHP php = other.gameObject.GetComponent<ALLHP>();
            //�÷��̾�� HP���� HP�� ���ҽ����ش�.
            php.HP--;
            //��Ʈ�Ŵ����� ��Ʈ�� ��������ش�.
            HitManager.instance.DoHitPlz();
            //���� Player.HP�� 0�̵Ǹ�
            if (php.HP <= 0)
            {
                //�ε��� �÷��̾�� �װ�
                Destroy(other.gameObject);
                //GameManager.������ �ҷ�����.gameOverUI�� ���ش�
                GameManager.instance.gameOverUI.SetActive(true);
                //���� �ð��� �����.
                Time.timeScale = 0f;
                //���� ���¸� GameOver ���·� �����ش�.
                GameManager.instance.gState = GameManager.GameState.GameOver;
            }
            TryDamage(1); // ���ʹ̰� �÷��̾�� �ε����� �� 
        }
       
        //���ʹ��� ü���� 0�̶��
        if (ehp.HP <= 0)
        {
            //exp ���� �������ش�. ���ʹ̰� ���� ��ġ�� +1
            GameObject exp = Instantiate(expFactory);
            exp.transform.position = transform.position;
            // ���� 5/100�� Ȯ���� HP������ ������.
            int rValue = Random.Range(0, 100);
            if (rValue < 5)
            {
                GameObject hpPotion = Instantiate(hpPotionFactory);
                hpPotion.transform.position = transform.position;
            }
            //ScoreManager�� �ҷ��� SCORE ������ �������ش�.
            ScoreManager.instance.SCORE++;
        }
        /* if (collision.gameObject.CompareTag("Bible"))
         {
             WeaponInfo info = collision.gameObject.GetComponent<WeaponInfo>();
             float damage = DamageManager.instance.GetDamage(info.type);
             //������ ó���� �ϰ� 
             //�ı��� �Ƚ�Ų��. 
             TryDamage(damage);
         }
         else
         {
         }*/



    }

}
