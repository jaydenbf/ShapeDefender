using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null;
    // public static GameManager TheGameManager() { return sGameManager; }
    public CameraSupport mMainCameraSupport;
    public MouseController mMouseMovement;
    private bool tileClick = true;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    public float outerLeft = -10f;
    public float outerRight = 10f;


    // Awake is called before the first frame update
    void Awake()
    {
        GameManager.sTheGlobalBehavior = this;
        // ButtonBehavior.setGameManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            tileClick = !tileClick;
        }

        // Return to base
        if (Input.GetKeyUp(KeyCode.N))
        {
            mMainCameraSupport.MoveTo(0f, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(tileClick)
            {
                mMouseMovement.firstClickTile();
            }
            else
            {
                // mMainCameraSupport.isOrthographizSize()

                    Vector3Int p = mMouseMovement.getmousePosition();
                    mMainCameraSupport.MoveTo(p.x, p.y);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (tileClick)
            {
                mMouseMovement.secondClickTile();
            }
        }


    }

    #region Bound Support
    public CameraSupport.WorldBoundStatus CollideWorldBound(Bounds b) { return mMainCameraSupport.CollideWorldBound(b); }
    #endregion

}
