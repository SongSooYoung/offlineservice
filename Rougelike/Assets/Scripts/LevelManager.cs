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

    public int maxCreateCount;
    // ���� ������ Ƚ��
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
            // ���� killCount�� maxCreateCount�̻��̸�
            while (exp >= maxCreateCount)
            {
                exp -= maxCreateCount;
                // ������ 1 ������Ű��ʹ�.
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



