using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//������ ǥ���ϰ� �ʹ�
//������ ���ŵǸ� Ui���� �ٿ��ϰ�ʹ�
//���� �Ѿ˰� �ε������� ������ 1�� ������Ű�� �ʹ�

public class ScoreManager : MonoBehaviour
{
    //�̱���
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    int score = 0;
    public Text textScore = null;

    //property : �Լ��ε� ����ó�� ����� �� �ִ�(Get,Set�� ������ �ִ�)
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
        //�¾ �� ������ 0������ �ϰ� UI���� 0���̶�� ǥ���ϰ� �ʹ�
        SCORE = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
