using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitManager : MonoBehaviour
{
    public static HitManager instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject imageHit;
    // Start is called before the first frame update
    void Start()
    {
        imageHit.SetActive(false);
        //ImageHit 게임오브젝트를 보였다가 0.1초 후에 안보이게 하는 기능을 만들고싶다
    }
    public void DoHitPlz()
    {
        StopCoroutine("IEDoHit");
        StartCoroutine("IEDoHit");
    }
    IEnumerator IEDoHit()
    {
        //보이게 한다.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //안 보이게 한다.
        imageHit.SetActive(false);

    }

}
