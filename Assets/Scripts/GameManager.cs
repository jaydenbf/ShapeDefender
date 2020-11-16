using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null;
    // public static GameManager TheGameManager() { return sGameManager; }
    public CameraSupport mMainCameraSupport;
    public MouseController mMouseMovement;

    public float dragSpeed = 6.5f;
    public float panBorderThickness = 200f;
    public Vector2 panLimit;


    public Text redCtxt;
    public Text greenCtxt;
    public Text blueCtxt;
    public Text redStxt;
    public Text greenStxt;
    public Text blueStxt;
    public static float redCircles = 0;
    public static float greenCircles = 0;
    public static float blueCircles = 0;
    public static float redSquares = 0;
    public static float greenSquares = 0;
    public static float blueSquares = 0;

    private bool tileClick = true;

    // Awake is called before the first frame update
    void Awake()
    {
        GameManager.sTheGlobalBehavior = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = mMainCameraSupport.getPos();

        redCtxt.text = Mathf.Floor(redCircles).ToString();
        greenCtxt.text = Mathf.Floor(greenCircles).ToString();
        blueCtxt.text = Mathf.Floor(blueCircles).ToString();
        redStxt.text = Mathf.Floor(redSquares).ToString();
        greenStxt.text = Mathf.Floor(greenSquares).ToString();
        blueStxt.text = Mathf.Floor(blueSquares).ToString();


        //if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        //{
        //    p.y += dragSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness)
        //{
        //    p.y -= dragSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        //{
        //    p.x += dragSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        //{
        //    p.x -= dragSpeed * Time.deltaTime;
        //}

        if (Input.GetKey("w"))
        {
            p.y += dragSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            p.y -= dragSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            p.x += dragSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            p.x -= dragSpeed * Time.deltaTime;
        }

        // Check for Bounds 
        p.x = Mathf.Clamp(p.x, -panLimit.x, panLimit.x);
        p.y = Mathf.Clamp(p.y, -panLimit.y, panLimit.y);
        
        // Move Camera
        mMainCameraSupport.MoveTo(p);


        // Return to base
        if (Input.GetKeyUp(KeyCode.N))
        {
            Vector3 p1 = new Vector3(0, 0, -10);
            mMainCameraSupport.MoveTo(p1);
        }

        if (Input.GetMouseButtonDown(0))
        {

             mMouseMovement.firstClickTile();

        }
        else if (Input.GetMouseButtonUp(0))
        {

             mMouseMovement.secondClickTile();
        }
    }

}
