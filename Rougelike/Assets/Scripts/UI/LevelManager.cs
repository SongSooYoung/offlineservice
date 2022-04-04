using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾��� ������ ǥ���ϰ�ʹ�.
// ���� ������, ���� ���� Ƚ��(����ġ)
// ���� �ı��ɶ� KillCount�� 1 ������Ű��ʹ�.
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }
    //�̱���

    int maxExp;
    //�ִ�ġ
    int level;
    //����
    int exp;
    //����ġ
    public Text textLevel;
    //���� �ؽ�Ʈ


    public int vLevel;
    public float �ӽð���ġ�����;


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
            // �迭�� ���� ���
            maxExp = needExp[level];
        }
    }
    //������Ƽ
    //---------------------------------------
    public Slider sliderExp;
    //---------------------------------------

    public int EXP

    {
        get { return exp; }
        set
        {
            �ӽð���ġ����� += value - exp;
            print("����ġȹ�� : " + (value - exp));

            exp = value;

            if (�ӽð���ġ����� > 0)
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
    //������Ƽ
    //---------------------------------------


    //���� exp�� maxExp �̻��̶��
    // ������ 1������Ű�� �ʹ�.
    // maxExp�� ������ �����ϰ� �ϰ�ʹ�.

    void Start()//ó�� ���� ���� ��
    {
        Level = 1; // 1������ �����ϰ�
        EXP = 0; // ����ġ�� 0���� �ʱ�ȭ
        sliderExp.value = 0; // �����̴��� ���� 0
        sliderExp.maxValue = needExp[Level];// �迭�� ������ ���� �ִ뷮
        vLevel = Level;
        �ӽð���ġ����� = EXP;
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
                //���׷��̵� â�� Ȱ��ȭ�Ѵ�
                GameManager.instance.gameLevelUp.SetActive(true);
                //���� �ӵ��� 0������� ��ȯ�Ѵ�.
                Time.timeScale = 0f;
                //���� ���¸� �Ͻ� ���� ���·� �����Ѵ�.
                GameManager.instance.gState = GameManager.GameState.LevelUp;
                if(vLevel>25)
                {
                    GameManager.instance.gameLevelUp.SetActive(false);
                    Time.timeScale = 1f;
                    GameManager.instance.gState = GameManager.GameState.Run;

                }
                //0���� �ʱ�ȭ
                sliderExp.value = 0;
                sliderExp.maxValue = needExp[vLevel];
            }

            float �ѱ氪 = Time.deltaTime * aniSpeed;
            if (�ѱ氪 >= �ӽð���ġ�����)
            {
                �ѱ氪 = �ӽð���ġ�����;
            }

            sliderExp.value += �ѱ氪;
            �ӽð���ġ����� -= �ѱ氪;

            textLevel.text = "Lv " + vLevel;
            if (�ӽð���ġ����� == 0)
            {
                isAnimation = false;
            }
        }
    }
    //---------------------------------------

}
