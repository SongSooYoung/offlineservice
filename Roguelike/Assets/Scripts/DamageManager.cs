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
    //무기의 종류
    public WeaponType type;
    //공격력
    public float value;
    //추가공격력
    public float addValue;
    //레벨
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
        // 최종공격력 = 기본공격력 + (추가공격력 * 레벨)

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
