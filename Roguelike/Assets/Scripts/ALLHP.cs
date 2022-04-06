using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ALLHP : MonoBehaviour
{
    public int maxHP = 5;
    float hp;
    //유니티에서 슬라이더를 넣어준다.
    public Slider sliderHP;
    //GET,SET 체력을 반환해준다.
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderHP.value = hp;
        }
    }
    //시작 시 슬라이더의 체력을 최대체력으로 
    void Start()
    {
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }
}
