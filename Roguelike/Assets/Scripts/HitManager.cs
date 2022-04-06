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
        //ImageHit ���ӿ�����Ʈ�� �����ٰ� 0.1�� �Ŀ� �Ⱥ��̰� �ϴ� ����� �����ʹ�
    }
    public void DoHitPlz()
    {
        StopCoroutine("IEDoHit");
        StartCoroutine("IEDoHit");
    }
    IEnumerator IEDoHit()
    {
        //���̰� �Ѵ�.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //�� ���̰� �Ѵ�.
        imageHit.SetActive(false);

    }
    void Update()
    {
        //���ӻ��°� '���� ��' ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.instance.gState != GameManager.GameState.Run)
        {
            return;
        }
    }


    }
