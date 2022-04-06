using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   //싱글톤 변수
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    //게임 상태 상수
    public enum GameState
    {
        Ready,
        Run,
        LevelUp,
        Pause,
        GameOver
    }
    //현재의 게임 상태 변수
    public GameState gState;
    //게임 상태 UI 오브젝트 변수
    public GameObject gameLabel;
    //옵션 화면 UI오브젝트 변수
    public GameObject gameOption;
    //Enemy.cs에 플레이어 체력이 0이 되면 "게임오버 UI"를 키고싶다.
    public GameObject gameOverUI;
    //플레이어의 레벨이 상승하면 "레벨업 UI"를 키고싶다.
    public GameObject gameLevelUp;
    //게임 상태 UI 텍스트 컴포넌트 변수
    Text gameText;
    public LightningLvUpGroup lightningLvUpGroup;
    public FireWandLvUpGroup fireWandLvUpGroup;
    public BibleLvUpGroup bibleLvUpGroup;
    public MagicWandLvUpGroup magicWandLvUpGroup;
    public KnifeLvUpGroup knifeLvUpGroup;
    public WhipLvUpGroup whipLvUpGroup;

    public GameObject LightningButton;
    public GameObject FireButton;
    public GameObject MagicWandButton;
    public GameObject KnifeButton;
    public GameObject BibleButton;
    public GameObject WhipButton;

    void Start()
    {

        //초기 게임 상태를 준비 상태로 설정한다.
        gState = GameState.Ready;
        //게임 상태 UI오브젝트에서 Text 컴포넌트를 가져온다
        gameText = gameLabel.GetComponent<Text>();
        //상태 텍스트의 내용을 'Ready...'로 한다.
        gameText.text = "Ready...";
        //상태 텍스트의 색상을 원하는 색상으로 한다.
        gameText.color = new Color32(255, 185, 0, 255);
        //게임 준비-> 게임 중 상태로 전환하기
        StartCoroutine(ReadyToStart());

    }

    public void RValue()
    {
        // 랜덤으로 처리할 버튼의 목록을 만든다.
        GameObject[] buttons = { LightningButton, FireButton, MagicWandButton, KnifeButton, BibleButton, WhipButton };

        // 전체 인덱스 목록을 만든다.
        // 버튼은 모두 보이지않게 해놓는다.
        List<int> indexs = new List<int>();
        for (int i = 0; i < buttons.Length; i++)
        {
            indexs.Add(i);
            buttons[i].SetActive(false);
        }
        // 선택 리스트
        List<int> chooseList = new List<int>();

        // 전체 인덱스 목록에서 랜덤으로 하나 골라서 지우고 그것을 선택 리스트에 담는다.
        int opp = 2;
        for (int i = 0; i < opp; i++)
        {
            int rValue = indexs[Random.Range(0, indexs.Count)];
            indexs.Remove(rValue);
            chooseList.Add(rValue);
        }

        // 선택 항목만 보이게한다.
        for (int i = 0; i < chooseList.Count; i++)
        {
            buttons[chooseList[i]].SetActive(true);
        }
    }

    IEnumerator ReadyToStart()
    {
        //2초간 대기한다.
        yield return new WaitForSeconds(2f);
        //상태 텍스트의 내용을 'Go!'로 한다.
        gameText.text = "Go!";
        //0.5초간 대기한다.
        yield return new WaitForSeconds(0.5f);
        //상태 텍스트를 비활성화 한다.
        gameLabel.SetActive(false);
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }

    //옵션 화면 켜기
    public void OpenOptionWindow()
    {
        //옵션 창을 활성화한다
        gameOption.SetActive(true);
        //게임 속도를 0배속으로 전환한다.
        Time.timeScale = 0f;
        //게임 상태를 일시 정지 상태로 변경한다.
        gState = GameState.Pause;
    }
    //계속하기 옵션
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
    }
    //다시하기 옵션
    public void ReStartGame()
    {
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //현재 씬 번호를 다시 로드한다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //라이트닝 블럭
    public void LightningLevelUpWindow() // 임의로 만든 버튼! 해당 버튼을 클릭하면 
    {
        lightningLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }
    //나이프 블럭
    public void KnifeLevelUpWindow() // 임의로 만든 버튼! 해당 버튼을 클릭하면 
    {
        knifeLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }
    //휩 블럭
    public void WhipLevelUpWindow() // 임의로 만든 버튼! 해당 버튼을 클릭하면 
    {
        whipLvUpGroup.SetCount();

        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }
    //마법지팡이 블럭
    public void MagicWandLevelUpWindow() // 임의로 만든 버튼! 해당 버튼을 클릭하면 
    {
        magicWandLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }
    //파이어완드 블럭
    public void FireWandLevelUpWindow() // 임의로 만든 버튼! 해당 버튼을 클릭하면 
    {
        fireWandLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }
    //바이블 블럭
    public void BibleLevelUpWindow() // 임의로 만든 버튼! 해당 버튼을 클릭하면 
    {
        bibleLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //게임속도를 1배속으로 전환한다.
        Time.timeScale = 1f;
        //상태를 '게임 중' 상태로 변경한다.
        gState = GameState.Run;
    }


    //게임 종료 옵션
    public void QuitGame()
    {
        //어플리케이션을 종료한다.
        Application.Quit();
        print("GameQuit");
    }
}
