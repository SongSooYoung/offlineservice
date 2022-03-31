using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ð����� �����忡�� ���� ���� �� ��ġ�� ������ ����ʹ�

public class EnemyManager : MonoBehaviour
{
    //�����ð�
    float createTime = 1;
    //����ð�
    float currentTime = 0;
    public float creatTimemin = 1;
    public float creatTimemax = 3;
    //������
    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(creatTimemin, creatTimemax);
    }

    // Update is called once per frame
    void Update()
    {
        //����ð��� �����ϴٰ� 
        currentTime += Time.deltaTime;

        if (createTime < currentTime)
        {
            //���� ���ӿ����� ���� �ʾҴٸ�
            if (false == GameManager.instance.GameOverUI.activeSelf)
            {
                GameObject enemy = Instantiate(enemyFactory);

                enemy.transform.position = transform.position;

            }
            currentTime = 0;
        }
    }
}
