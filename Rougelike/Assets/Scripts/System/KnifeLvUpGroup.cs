using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLvUpGroup : MonoBehaviour
{
    public GameObject Lv1;
    public GameObject Lv2;
    public GameObject Lv3;
    public GameObject Lv4;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        Lv1.SetActive(false);
        Lv2.SetActive(false);
        Lv3.SetActive(false);
        Lv4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {





    }
    public void SetCount()
    {
        {
            count++;
            if (count > 4)
            {
                count = 4; // lv 4인 무기는 버튼을 호출하면 안 된다.

            }

            if (count == 0)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(false);
                Lv3.SetActive(false);
                Lv4.SetActive(false);
            }
            else if (count == 1)
            {
                Lv1.SetActive(true);
                Lv2.SetActive(false);
                Lv3.SetActive(false);
                Lv4.SetActive(false);
            }
            else if (count == 2)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(true);
                Lv3.SetActive(false);
                Lv4.SetActive(false);
            }
            else if (count == 3)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(false);
                Lv3.SetActive(true);
                Lv4.SetActive(false);
            }
            else if (count == 4)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(false);
                Lv3.SetActive(false);
                Lv4.SetActive(true);
            }
        }
    }
}
