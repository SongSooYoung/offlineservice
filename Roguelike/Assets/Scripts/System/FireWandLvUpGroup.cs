using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireWandLvUpGroup : MonoBehaviour

{
    public GameObject Lv1;
    public GameObject Lv2;
    public GameObject Lv3;
    public GameObject Lv4;
    public GameObject Lv1Icon;
    public GameObject Lv2Icon;
    public GameObject Lv3Icon;
    public GameObject Lv4Icon;
    int count;
    public GameObject FireWandLevelUpWindow;


    void Start()
    {
        Lv1.SetActive(false);
        Lv2.SetActive(false);
        Lv3.SetActive(false);
        Lv4.SetActive(false);

        Lv1Icon.SetActive(false);
        Lv2Icon.SetActive(false);
        Lv3Icon.SetActive(false);
        Lv4Icon.SetActive(false);
    }
    void Update()
    {





    }
    public void SetCount()
    {
        {
            count++;
           

            if (count == 0)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(false);
                Lv3.SetActive(false);
                Lv4.SetActive(false);

                Lv1Icon.SetActive(false);
                Lv2Icon.SetActive(false);
                Lv3Icon.SetActive(false);
                Lv4Icon.SetActive(false);
            }
            else if (count == 1)
            {
                Lv1.SetActive(true);
                Lv2.SetActive(false);
                Lv3.SetActive(false);
                Lv4.SetActive(false);

                Lv1Icon.SetActive(true);
                Lv2Icon.SetActive(false);
                Lv3Icon.SetActive(false);
                Lv4Icon.SetActive(false);
            }
            else if (count == 2)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(true);
                Lv3.SetActive(false);
                Lv4.SetActive(false);

                Lv1Icon.SetActive(true);
                Lv2Icon.SetActive(true);
                Lv3Icon.SetActive(false);
                Lv4Icon.SetActive(false);
            }
            else if (count == 3)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(false);
                Lv3.SetActive(true);
                Lv4.SetActive(false);

                Lv1Icon.SetActive(true);
                Lv2Icon.SetActive(true);
                Lv3Icon.SetActive(true);
                Lv4Icon.SetActive(false);
            }
            else if (count == 4)
            {
                Lv1.SetActive(false);
                Lv2.SetActive(false);
                Lv3.SetActive(false);
                Lv4.SetActive(true);

                Lv1Icon.SetActive(true);
                Lv2Icon.SetActive(true);
                Lv3Icon.SetActive(true);
                Lv4Icon.SetActive(true);

                FireWandLevelUpWindow.SetActive(false);
            }
        }
    }
}
