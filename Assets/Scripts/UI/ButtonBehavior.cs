using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    static private GameManager sGameManager = null;
    static public void setGameManager(GameManager g) { sGameManager = g; }

    private bool infoTab = false;

    public void OnButtonPress()
    {
        infoTab = !infoTab;
        sGameManager.activateInformationTab(infoTab);
    }
}
