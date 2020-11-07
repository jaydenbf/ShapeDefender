using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager sGameManager = null;
    public static GameManager TheGameManager() { return sGameManager; }
    public CameraSupport mCameraSupport = null;
    public CameraSupport mBGCamera = null;

    // Awake is called before the first frame update
    void Awake()
    {
        sGameManager = this;
        ButtonBehavior.setGameManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateInformationTab(bool activation)
    {
        // Turn On 
        if (activation)
        {
            // Activate BG Camera 
            mBGCamera.SetActive(true);
            mCameraSupport.SetViewprotSize(.8f, 1f);
            // Change Camera size / zoom

        }

        // Turn off
        if (!activation)
        {
            mBGCamera.SetActive(false);
            mCameraSupport.SetViewprotSize(1f, 1f);

            // Change Camera size / zoom 

        }
    }
}
