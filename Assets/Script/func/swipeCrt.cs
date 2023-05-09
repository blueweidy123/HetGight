
using UnityEngine;


public class swipeCrt : MonoBehaviour
{
    public SwipeDec swipe;

    void Start()
    {
        swipe = gameObject.GetComponentInParent<SwipeDec>();
    }


    void Update()
    {   
        if (swipe.SwipeLeft)
        {
            Debug.Log("swipe Left");
        }
        else if (swipe.SwipeRight)
        {
            Debug.Log("swipe Right");
        }
        else if (swipe.SwipeUp)
        {
                Debug.Log("swipe Up");
        }
            else if (swipe.SwipeDown)
        {
            Debug.Log("swipe Down");
        }
        if (swipe.Tap)
        {
            Debug.Log("taped");
        }
    }
}

