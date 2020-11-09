using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null;
    // public static GameManager TheGameManager() { return sGameManager; }
    public CameraSupport mMainCameraSupport;
    public CameraSupport mBGCamera;

    // Awake is called before the first frame update
    void Awake()
    {
        GameManager.sTheGlobalBehavior = this;
        // ButtonBehavior.setGameManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Bound Support
    public CameraSupport.WorldBoundStatus CollideWorldBound(Bounds b) { return mMainCameraSupport.CollideWorldBound(b); }
    #endregion 


    public void activateInformationTab(bool activation)
    {
        // Turn On 
        if (activation)
        {
            // Activate BG Camera 
            mBGCamera.SetActive(true);
            mMainCameraSupport.SetViewprotSize(.8f, 1f);
            // Change Camera size / zoom

        }

        // Turn off
        if (!activation)
        {
            mBGCamera.SetActive(false);
            mMainCameraSupport.SetViewprotSize(1f, 1f);

            // Change Camera size / zoom 

        }
    }
}
