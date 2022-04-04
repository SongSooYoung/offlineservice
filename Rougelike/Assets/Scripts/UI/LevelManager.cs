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
    //싱글톤

    int maxExp;
    //최대치
    int level;
    //레벨
    int exp;
    //경험치
    public Text textLevel;
    //레벨 텍스트


    public int vLevel;
    public float 임시경험치저장소;


    int[] needExp = {
        0, 1, 1, 1, 1,
        1, 1, 10, 10, 10,
        1, 1, 10, 10, 10,
        1, 1, 10, 10, 10,
        1, 1, 10, 10, 10,
    };
//---------------------------------------
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            // 배열을 쓰는 경우
            maxExp = needExp[level];
        }
    }
    //프로퍼티
    //---------------------------------------
    public Slider sliderExp;
    //---------------------------------------

    public int EXP

    {
        get { return exp; }
        set
        {
            임시경험치저장소 += value - exp;
            print("경험치획득 : " + (value - exp));

            exp = value;

            if (임시경험치저장소 > 0)
            {
                isAnimation = true;
            }
            while (exp >= maxExp)
            {
                exp -= maxExp;
                Level++;
            }

        }
    }
    //프로퍼티
    //---------------------------------------


    //만약 exp가 maxExp 이상이라면
    // 레벨을 1증가시키고 싶다.
    // maxExp를 레벨과 동일하게 하고싶다.

    void Start()//처음 게임 시작 시
    {
        Level = 1; // 1렙으로 시작하고
        EXP = 0; // 경험치는 0으로 초기화
        sliderExp.value = 0; // 슬라이더의 값도 0
        sliderExp.maxValue = needExp[Level];// 배열에 적어준 값이 최대량
        vLevel = Level;
        임시경험치저장소 = EXP;
    }
    //---------------------------------------
    float currentAniTime;
    public float aniSpeed = 10f;
    bool isAnimation;
    //---------------------------------------

    private void Update()
    {
        if (isAnimation)
        {
            if (sliderExp.value == sliderExp.maxValue)
            {
                print("Level Up!");
                vLevel++;
                //업그레이드 창을 활성화한다
                GameManager.instance.gameLevelUp.SetActive(true);
                //게임 속도를 0배속으로 전환한다.
                Time.timeScale = 0f;
                //게임 상태를 일시 정지 상태로 변경한다.
                GameManager.instance.gState = GameManager.GameState.LevelUp;
                if(vLevel>25)
                {
                    GameManager.instance.gameLevelUp.SetActive(false);
                    Time.timeScale = 1f;
                    GameManager.instance.gState = GameManager.GameState.Run;

                }
                //0으로 초기화
                sliderExp.value = 0;
                sliderExp.maxValue = needExp[vLevel];
            }

            float 넘길값 = Time.deltaTime * aniSpeed;
            if (넘길값 >= 임시경험치저장소)
            {
                넘길값 = 임시경험치저장소;
            }

            sliderExp.value += 넘길값;
            임시경험치저장소 -= 넘길값;

            textLevel.text = "Lv " + vLevel;
            if (임시경험치저장소 == 0)
            {
                isAnimation = false;
            }
        }
    }
    //---------------------------------------

}
