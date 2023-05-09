
using UnityEngine;

public class CrtCrt : MonoBehaviour
{
    private Vector2 startTouch, touchEnd, swipedelta;
    private Touch touch;

    private bool tap, swipe;
    void Update()
    {
        tap = swipe = false;
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = touch.position;
                    break;
                case TouchPhase.Ended:
                    touchEnd = touch.position;
                    if(startTouch == touchEnd)
                    {
                        tap = true;
                    }
                    if(startTouch != touchEnd)
                    {
                        swipe = true;
                    }
                    break;
            }

        }
    }

public bool Tap { get { return tap; } }
public bool Swipe { get { return swipe; } }
}
