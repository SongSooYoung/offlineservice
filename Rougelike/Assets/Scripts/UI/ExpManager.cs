using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public static ExpManager instance;

    private void Awake()
    {
        instance = this;
    }
    public int maxEXP = 3;
    int exp;

    public Slider sliderEXP;
    public int EXP
    {
        get { return exp; }
        set { exp = value;
            sliderEXP.value = exp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EXP = 0;
    }

}
