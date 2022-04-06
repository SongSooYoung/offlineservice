using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public float createTime = 1.5f;

    //현재시간
    float currentTime;

    //무기공장
    public GameObject fireFactory;

    public GameObject firePosition;  // 나는 움직일 거니까 포지션이 있어야함 ?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 현재시간이 증가하다가
        currentTime += Time.deltaTime;
        // 만약 현재시간이 증가시간을 초과하면
        if (currentTime > createTime)
        {
            // 무기공장에서 무기를 만들어 내 위치에 가져다 놓고싶다.
            GameObject fire = Instantiate(fireFactory);
            fire.transform.position = firePosition.transform.position;
            //  현재시간을 0으로 초기화

            currentTime = 0;
            transform.LookAt(transform.position);

            fire.transform.forward = transform.forward;
        }
    }
}
