using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ALLHP : MonoBehaviour
{
    public int maxHP = 5;
    float hp;
    //����Ƽ���� �����̴��� �־��ش�.
    public Slider sliderHP;
    //GET,SET ü���� ��ȯ���ش�.
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderHP.value = hp;
        }
    }
    //���� �� �����̴��� ü���� �ִ�ü������ 
    void Start()
    {
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }
}
