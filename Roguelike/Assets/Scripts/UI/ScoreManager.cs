using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//점수를 표현하고 싶다
//점수가 갱신되면 Ui에도 바영하고싶다
//적이 총알과 부딪혔을때 점수를 1점 증가시키고 싶다

public class ScoreManager : MonoBehaviour
{
    //싱글톤
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    int score = 0;
    public Text textScore = null;

    //property : 함수인데 변수처럼 사용할 수 있다(Get,Set을 가지고 있는)
    public int SCORE
    {
        get { return score; }
        set
        {
            score = value;
            textScore.text = score + " ";
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //태어날 때 점수를 0점으로 하고 UI에도 0점이라고 표현하고 싶다
        SCORE = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
