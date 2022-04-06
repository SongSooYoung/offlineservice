using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   //�̱��� ����
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    //���� ���� ���
    public enum GameState
    {
        Ready,
        Run,
        LevelUp,
        Pause,
        GameOver
    }
    //������ ���� ���� ����
    public GameState gState;
    //���� ���� UI ������Ʈ ����
    public GameObject gameLabel;
    //�ɼ� ȭ�� UI������Ʈ ����
    public GameObject gameOption;
    //Enemy.cs�� �÷��̾� ü���� 0�� �Ǹ� "���ӿ��� UI"�� Ű��ʹ�.
    public GameObject gameOverUI;
    //�÷��̾��� ������ ����ϸ� "������ UI"�� Ű��ʹ�.
    public GameObject gameLevelUp;
    //���� ���� UI �ؽ�Ʈ ������Ʈ ����
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

        //�ʱ� ���� ���¸� �غ� ���·� �����Ѵ�.
        gState = GameState.Ready;
        //���� ���� UI������Ʈ���� Text ������Ʈ�� �����´�
        gameText = gameLabel.GetComponent<Text>();
        //���� �ؽ�Ʈ�� ������ 'Ready...'�� �Ѵ�.
        gameText.text = "Ready...";
        //���� �ؽ�Ʈ�� ������ ���ϴ� �������� �Ѵ�.
        gameText.color = new Color32(255, 185, 0, 255);
        //���� �غ�-> ���� �� ���·� ��ȯ�ϱ�
        StartCoroutine(ReadyToStart());

    }

    public void RValue()
    {
        // �������� ó���� ��ư�� ����� �����.
        GameObject[] buttons = { LightningButton, FireButton, MagicWandButton, KnifeButton, BibleButton, WhipButton };

        // ��ü �ε��� ����� �����.
        // ��ư�� ��� �������ʰ� �س��´�.
        List<int> indexs = new List<int>();
        for (int i = 0; i < buttons.Length; i++)
        {
            indexs.Add(i);
            buttons[i].SetActive(false);
        }
        // ���� ����Ʈ
        List<int> chooseList = new List<int>();

        // ��ü �ε��� ��Ͽ��� �������� �ϳ� ��� ����� �װ��� ���� ����Ʈ�� ��´�.
        int opp = 2;
        for (int i = 0; i < opp; i++)
        {
            int rValue = indexs[Random.Range(0, indexs.Count)];
            indexs.Remove(rValue);
            chooseList.Add(rValue);
        }

        // ���� �׸� ���̰��Ѵ�.
        for (int i = 0; i < chooseList.Count; i++)
        {
            buttons[chooseList[i]].SetActive(true);
        }
    }

    IEnumerator ReadyToStart()
    {
        //2�ʰ� ����Ѵ�.
        yield return new WaitForSeconds(2f);
        //���� �ؽ�Ʈ�� ������ 'Go!'�� �Ѵ�.
        gameText.text = "Go!";
        //0.5�ʰ� ����Ѵ�.
        yield return new WaitForSeconds(0.5f);
        //���� �ؽ�Ʈ�� ��Ȱ��ȭ �Ѵ�.
        gameLabel.SetActive(false);
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }

    //�ɼ� ȭ�� �ѱ�
    public void OpenOptionWindow()
    {
        //�ɼ� â�� Ȱ��ȭ�Ѵ�
        gameOption.SetActive(true);
        //���� �ӵ��� 0������� ��ȯ�Ѵ�.
        Time.timeScale = 0f;
        //���� ���¸� �Ͻ� ���� ���·� �����Ѵ�.
        gState = GameState.Pause;
    }
    //����ϱ� �ɼ�
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
    }
    //�ٽ��ϱ� �ɼ�
    public void ReStartGame()
    {
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���� �� ��ȣ�� �ٽ� �ε��Ѵ�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //����Ʈ�� ��
    public void LightningLevelUpWindow() // ���Ƿ� ���� ��ư! �ش� ��ư�� Ŭ���ϸ� 
    {
        lightningLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }
    //������ ��
    public void KnifeLevelUpWindow() // ���Ƿ� ���� ��ư! �ش� ��ư�� Ŭ���ϸ� 
    {
        knifeLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }
    //�� ��
    public void WhipLevelUpWindow() // ���Ƿ� ���� ��ư! �ش� ��ư�� Ŭ���ϸ� 
    {
        whipLvUpGroup.SetCount();

        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }
    //���������� ��
    public void MagicWandLevelUpWindow() // ���Ƿ� ���� ��ư! �ش� ��ư�� Ŭ���ϸ� 
    {
        magicWandLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }
    //���̾�ϵ� ��
    public void FireWandLevelUpWindow() // ���Ƿ� ���� ��ư! �ش� ��ư�� Ŭ���ϸ� 
    {
        fireWandLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }
    //���̺� ��
    public void BibleLevelUpWindow() // ���Ƿ� ���� ��ư! �ش� ��ư�� Ŭ���ϸ� 
    {
        bibleLvUpGroup.SetCount();
        /*  Debug.Log("test");*/
        gameLevelUp.SetActive(false);
        //���Ӽӵ��� 1������� ��ȯ�Ѵ�.
        Time.timeScale = 1f;
        //���¸� '���� ��' ���·� �����Ѵ�.
        gState = GameState.Run;
    }


    //���� ���� �ɼ�
    public void QuitGame()
    {
        //���ø����̼��� �����Ѵ�.
        Application.Quit();
        print("GameQuit");
    }
}
