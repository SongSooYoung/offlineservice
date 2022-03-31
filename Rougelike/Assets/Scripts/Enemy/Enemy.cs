using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Ÿ���� �÷��̾�� ��� �� �������� �̵��ϰ��
public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private GameObject target;
    NavMeshAgent agent;
    ALLHP ehp;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ehp = gameObject.GetComponent<ALLHP>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("Player");
        if (target)
        {
            agent.destination = target.transform.position;
        }
    }
    // �������� �ε��� ���� ȣ��Ǵ� �Լ�!
    // �������� �ε����� ���߰��忡�� 
    public GameObject explosionFactory;
    public GameObject coinFactory;

    
    public void TryDamage(float damageVelue)
    {
        print("HP : " + ehp.HP + ", damageVelue : " + damageVelue);

        ehp.HP -= damageVelue;
        if (ehp.HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject exp = Instantiate(explosionFactory);
        exp.transform.position = transform.position;
        Destroy(exp, 3);



        if (collision.gameObject.CompareTag("Weapon"))
        {
            WeaponInfo info = collision.gameObject.GetComponent<WeaponInfo>();
            float damage = DamageManager.instance.GetDamage(info.type);
            print("TryDamage!!");
            TryDamage(damage);

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            //���ʹ̰� �÷��̾�� �ε����� �÷��̾��� HP�� ���δ�
            ALLHP php = collision.gameObject.GetComponent<ALLHP>();
            php.HP--;
            HitManager.instance.DoHitPlz();

            if (php.HP <= 0)
            {
                Destroy(collision.gameObject);
                GameManager.instance.GameOverUI.SetActive(true);
            }

            TryDamage(1);
        }
        else
        {
            //���װ�
            Destroy(collision.gameObject);
        }

        if (ehp.HP <= 0)
        {
            GameObject coin = Instantiate(coinFactory);
            coin.transform.position = transform.position;
            ScoreManager.instance.SCORE++;
        }
    }

}
