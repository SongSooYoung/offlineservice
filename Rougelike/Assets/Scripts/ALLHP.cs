using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ALLHP : MonoBehaviour
{
    public int maxHP = 5;
    float hp;
    public Slider sliderHP;
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderHP.value = hp;
        }
    }
    void Start()
    {
        //�¾ �� �ִ�ü������ �¾��ʹ�.
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }
    public void Update()
    {
       
    }
}
