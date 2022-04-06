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
    //Spawn 목록중에 임의로 하나를 선택해서 그 위치에 생성하고 싶다.

    //생성시간
    float createTime = 1;
    //현재시간
    float currentTime;
    //최소 생성시간
    public float creatTimemin = 1;
    //최대 생성시간
    public float creatTimemax = 3;
    //에너미가 생성되는 공간
    public GameObject enemyFactory;
    public Transform[] spawnList;
    //적을 생성한 횟수
    public int creatCount;
    public int maxCreatCount;
    void Start()
    {
        //생성시간은 최소와 최대 랜덤으로 생성됨.
        createTime = Random.Range(creatTimemin, creatTimemax);

    }
    void Update()
    {
        //게임상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if (GameManager.instance.gState != GameManager.GameState.Run)
        {
            return;
        }

        //현재시간이 증가하다가 
        currentTime += Time.deltaTime;
        //만약 현재시간이 생성시간보다 커지면
        if (createTime < currentTime)
        {
            //만약 게임오버가 되지 않았다면
            if (false == GameManager.instance.gameOverUI.activeSelf)
            {
                //생성횟수 < 최대생성횟수
                if (creatCount < maxCreatCount)
                {
                    //에너미가 생성되는 공간에서 생성해준다.
                    GameObject enemy = Instantiate(enemyFactory);

                    creatCount++;
                    // spawnlist의 임의의 위치에 배치하고싶다.
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
