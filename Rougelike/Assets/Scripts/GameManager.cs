using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 태어날 때 GameOverUI를 비활성화하고싶다
// 플레이어가 파괴될 때 GameOverUI를 활성화 하고싶다
// Restart, Quit 버튼이 눌러졌을 때 호출될 함수를 구현하고싶다.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 GameOverUI를 비활성화하고싶다
        GameOverUI.SetActive(false);
    }
    // Restart, Quit 버튼이 눌러졌을 때 호출될 함수를 구현하고싶다.

    public void OnClickRestart()
    {
        print("OnClickRestart");
        //현재 Scene을 다시 로드하고 싶다
        SceneManager.LoadScene(0);
    }
    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }
}
