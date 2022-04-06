using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Fire,
    Knife,
    Lightning,
    Magic,
    Whip, 
    Bible,
}

[System.Serializable]
public class DamageInfo
{
    //������ ����
    public WeaponType type;
    //���ݷ�
    public float value;
    //�߰����ݷ�
    public float addValue;
    //����
    public int level;
}

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;
    private void Awake()
    {
        instance = this;
    }
    
    internal DamageInfo GetDamageInfo(WeaponType type)
    {
        int index = (int)type;
        return damageInfoList[index];
    } 

    public DamageInfo[] damageInfoList;

    public float GetDamage(WeaponType type)
    {
        // �������ݷ� = �⺻���ݷ� + (�߰����ݷ� * ����)

        int index = (int)type;
        int level = damageInfoList[index].level;
        return damageInfoList[index].value + (damageInfoList[index].addValue * level);
    }


    void Start()
    {

    }

    void Update()
    {

    }
}