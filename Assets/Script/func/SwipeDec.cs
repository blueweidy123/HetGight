
using UnityEngine;

public class SwipeDec : MonoBehaviour
{
    private bool tap,taping, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool  swiped;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
//------------------------------------------swipe------------------------------------------------------------
        swiped = tap = taping = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
      
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                tap = true;
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate distance
        swipeDelta = Vector2.zero;
        if(isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
        //Cross the deadzone?
        if (swipeDelta.magnitude > 25)
        {
            swiped = true;
            checkDIR();
            Reset();
        }
    }
    private void checkDIR()
    {
        if (swiped)
        {
            //Direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left of Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (x < 0)
                    swipeUp = true;
                else
                    swipeDown = true;
            }
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
    public static bool isDoubleTap()
    {
        bool result = false;
        float maxTimeWait = 1;
        float VariancePos = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPosLength = Input.GetTouch(0).deltaPosition.magnitude;
            if (DeltaTime > 0 && DeltaTime < maxTimeWait && DeltaPosLength < VariancePos)
                result = true;
        }

        return result;
    }
    public bool Tap { get { return tap; } }
    public bool Swipe { get { return swiped; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
