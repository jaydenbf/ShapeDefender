using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int cash = 1000;
    public int redCount = 0;
    public int greenCount = 0;
    public int blueCount = 0;

    public int redPrice = 25;
    public int greenPrice = 50;
    public int bluePrice = 100;

    public Text cashUI = null;
    public Text redUI = null;
    public Text greenUI = null;
    public Text blueUI = null;

    void Start()
    {
        
    }

    void Update()
    {
        cashUI.text = "Cash:\t" + cash;
        redUI.text = "R:\t\t\t" + redCount;
        greenUI.text = "G:\t\t" + greenCount;
        blueUI.text = "B:\t\t\t" + blueCount;
    }

    public bool canAfford(string color)
    {
        if(color == "Red Square")
        {
            if (cash - redPrice >= 0)
            {
                return true;
            }

        } else if(color == "Green Square")
        {
            if(cash - greenPrice >= 0)
            {
                return true;
            }

        } else if(color == "Blue Square")
        {
            if(cash - bluePrice >= 0)
            {
                return true;
            }
        }

        return false;
    }
}
