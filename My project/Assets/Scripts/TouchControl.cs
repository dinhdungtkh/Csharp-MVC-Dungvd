using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TouchControl : MonoBehaviour
{
    //public TextMeshProUGUI phaseDisplayText;
    //private Touch theTouch;
    //private float timeTouchEnded;

    //private float displayTime = 0.5f;

    //public void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        theTouch = Input.GetTouch(0);
    //        if (theTouch.phase == TouchPhase.Ended)
    //        {
    //            phaseDisplayText.text = theTouch.phase.ToString();
    //            timeTouchEnded = Time.time;
    //        }
    //        else if (Time.time - timeTouchEnded > displayTime)
    //        {
    //            phaseDisplayText.text = theTouch.phase.ToString();
    //            timeTouchEnded = Time.time;
    //        }
    //    }
    //    else if (Time.time - timeTouchEnded > displayTime)
    //    { phaseDisplayText.text = ""; }
    //}

    public static int playerTurnAxisTouch  =  0;
    public static int playerMoveAxisTouch  =  0;

   void Start()
    {
        playerTurnAxisTouch = 0;
        playerMoveAxisTouch  =  0;
    } 

    public void playerLeftUIPointerDown()
    {
        playerTurnAxisTouch = -1;
    }
    public void playerRightUIPointerDown()
    {
        playerTurnAxisTouch = 1;
    }

    public void playerLeftUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }
    public void playerRightUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }   
    

    public void playerMoveUIPointerDown()
    {
        playerMoveAxisTouch = 1;
    }
    public void playerMoveUIPointerUp()
    {
        playerMoveAxisTouch = 0;
    }
    void Update()
    {
       
    }   
}
