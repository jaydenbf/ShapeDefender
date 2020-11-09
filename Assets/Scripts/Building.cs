using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPrototype : MonoBehaviour
{
    Vector3 location;
    string color;
    int counter;
    private resourcePrototype resourceManager;

    // Start is called before the first frame update
    void Start()
    {
        resourceManager = GameObject.FindObjectOfType<resourcePrototype>();
    }

    // Update is called once per frame
    void Update()
    {
        if (color == "blue")
        {
            counter++;
            if (counter > 1000)
            {
                resourceManager.addBlue();
                counter = 0;
            }
        }
        else if (color == "red")
        {
            counter++;
            if (counter > 1000)
            {
                resourceManager.addRed();
                counter = 0;
            }
        }
        else if (color == "green")
        {
            counter++;
            if (counter > 1000)
            {
                resourceManager.addGreen();
                counter = 0;
            }
        }
    }

    internal void SetLocation(Vector3 locationIn)
    {
        location = locationIn;
    }

    internal void SetColor(string colorIn)
    {
        color = colorIn;
    }
}