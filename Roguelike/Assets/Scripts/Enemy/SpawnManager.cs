using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private void Awake()
    {
        instance = this;
    }
    //Spawn ����߿� ���Ƿ� �ϳ��� �����ؼ� �� ��ġ�� �����ϰ� �ʹ�.

    //�����ð�
    float createTime = 1;
    //����ð�
    float currentTime;
    //�ּ� �����ð�
    public float creatTimemin = 1;
    //�ִ� �����ð�
    public float creatTimemax = 3;
    //���ʹ̰� �����Ǵ� ����
    public GameObject enemyFactory;
    public Transform[] spawnList;
    //���� ������ Ƚ��
    public int creatCount;
    public int maxCreatCount;
    void Start()
    {
        //�����ð��� �ּҿ� �ִ� �������� ������.
        createTime = Random.Range(creatTimemin, creatTimemax);

    }
    void Update()
    {
        //���ӻ��°� '���� ��' ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.instance.gState != GameManager.GameState.Run)
        {
            return;
        }

        //����ð��� �����ϴٰ� 
        currentTime += Time.deltaTime;
        //���� ����ð��� �����ð����� Ŀ����
        if (createTime < currentTime)
        {
            //���� ���ӿ����� ���� �ʾҴٸ�
            if (false == GameManager.instance.gameOverUI.activeSelf)
            {
                //����Ƚ�� < �ִ����Ƚ��
                if (creatCount < maxCreatCount)
                {
                    //���ʹ̰� �����Ǵ� �������� �������ش�.
                    GameObject enemy = Instantiate(enemyFactory);

                    creatCount++;
                    // spawnlist�� ������ ��ġ�� ��ġ�ϰ�ʹ�.
                    int randomValue = Random.Range(0, spawnList.Length);
                    Vector3 pos = spawnList[randomValue].position;
                    enemy.transform.position = pos;
                }
                currentTime = 0;
                createTime = Random.Range(creatTimemin, creatTimemax);
            }
            
        }
    }
}
