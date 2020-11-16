using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int redCircle = 0;
    public int redSquare = 0;
    public int greenCircle = 0;
    public int greenSquare = 0;
    public int blueSquare = 0;
    public int blueCircle = 0;

    public int harvesterPrice = 50;
    public int towerPrice = 50;
    public int upgradePrice = 80;

    public Text redUI = null;
    public Text greenUI = null;
    public Text blueUI = null;

    void Start()
    {
        
    }

    void Update()
    {
        redUI.text = "R:\t\t\t" + redCircle;
        greenUI.text = "G:\t\t" + greenCircle;
        blueUI.text = "B:\t\t\t" + blueCircle;
    }

    public void addRedCircle()
    {
        redCircle++;
    }
    public void addRedSquare()
    {
        redSquare++;
    }
    public void addBlueCircle()
    {
        blueCircle++;
    }
    public void addBlueSquare()
    {
        blueSquare++;
    }
    public void addGreenCircle()
    {
        greenCircle++;
    }
    public void addGreenSquare()
    {
        greenSquare++;
    }

    public bool buyHarvester()
    {
        if (greenCircle >= harvesterPrice)
        {
            greenCircle = greenCircle - harvesterPrice;
            return true;
        }
        else
            return false;
    }

    public bool buyTower()
    {
        if (redCircle >= towerPrice)
        {
            redCircle = redCircle - towerPrice;
            return true;
        }
        else
            return false;
    }

    public bool buyUpgrade()
    {
        if (blueCircle >= upgradePrice)
        {
            blueCircle = blueCircle - upgradePrice;
            return true;
        }
        else
            return false;
    }

    public bool canAfford(string color)
    {
        if (color == "Red Square")
        {
            if (redCircle >= 0)
            {
                return true;
            }

        }
        else if (color == "Green Square")
        {
            if (greenCircle >= 0)
            {
                return true;
            }

        }
        else if (color == "Blue Square")
        {
            if (blueCircle >= 0)
            {
                return true;
            }
        }

        return false;
    }
}