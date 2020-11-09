using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Shop shop = null;

    void Start()
    {
        DragAndDrop.InitializeShop(shop);
    }

    void Update()
    {

    }
}
