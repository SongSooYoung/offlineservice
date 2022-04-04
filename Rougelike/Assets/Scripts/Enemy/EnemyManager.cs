using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//일정시간마다 적공장에서 적을 만들어서 내 우치에 가져다 놓고싶다

public class EnemyManager : MonoBehaviour
{
    //---------------------------------------
    //생성시간
    float createTime = 1;
    //현재시간
    float currentTime = 0;
    public float creatTimemin = 1;
    public float creatTimemax = 3;
    //적공장
    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(creatTimemin, creatTimemax);
    }
    //---------------------------------------
    void Update()
    {
        //게임상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if (GameManager.instance.gState != GameManager.GameState.Run)
        {
            return;
        }
        //현재시간이 증가하다가 
        currentTime += Time.deltaTime;

        if (createTime < currentTime)
        {
            //만약 게임오버가 되지 않았다면
            if (false == GameManager.instance.gameOverUI.activeSelf)
            {
                GameObject enemy = Instantiate(enemyFactory);

                enemy.transform.position = transform.position;

            }
            currentTime = 0;
        }
    }
}
