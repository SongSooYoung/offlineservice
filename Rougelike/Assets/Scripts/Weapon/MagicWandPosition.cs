using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandPosition : MonoBehaviour
{
    public float createTime = 0.1f;

    float currentTime;

    public GameObject magicFactory;
    public GameObject magic2Factory;

    public GameObject magicPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject GetFactory()
    {
        DamageInfo info = DamageManager.instance.GetDamageInfo(WeaponType.Magic);
        if (info.level == 1)
        {
            return magicFactory;
        }
        else
        {
            return magic2Factory;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // 만약 현재시간이 증가시간을 초과하면
        if (currentTime > createTime)
        {
            // 무기공장에서 무기를 만들어 내 위치에 가져다 놓고싶다.
            GameObject whip = Instantiate(GetFactory());
            whip.transform.position = magicPosition.transform.position;
            //  현재시간을 0으로 초기화

            currentTime = 0;
            transform.LookAt(transform.position);
        }
    }
}