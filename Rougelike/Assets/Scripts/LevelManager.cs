using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어의 레벨을 표현하고싶다.
// 적의 생성수, 적을 죽인 횟수(경험치)
// 적이 파괴될때 KillCount를 1 증가시키고싶다.
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int maxCreateCount;
    // 적을 생성한 횟수
    public int createCount;

    int level;
    public Text textLevel;
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            maxCreateCount = level;
            textLevel.text = "Lv " + level;
            sliderEXP.maxValue = level;
            sliderEXP.value = exp;
            createCount = 0;
        }
    }

    int exp;
    public Slider sliderEXP;
    public Text textexpCountPer;
    public int KillCount
    {
        get { return exp; }
        set
        {
            exp = value;
            textexpCountPer.text = ((float)exp / maxCreateCount * 100f) + "%";
            // 만약 killCount가 maxCreateCount이상이면
            while (exp >= maxCreateCount)
            {
                exp -= maxCreateCount;
                // 레벨을 1 증가시키고싶다.
                Level++;

                textexpCountPer.text = ((float)exp / maxCreateCount * 100f) + "%";
            }

            sliderEXP.value = exp;
        }
    }

    public bool CanCreateEnemy()
    {
        return createCount < maxCreateCount;
    }


    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        KillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}



