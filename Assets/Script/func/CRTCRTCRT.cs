
using UnityEngine;

public class CRTCRTCRT : MonoBehaviour
{
    public CrtCrt CRT;
    // Start is called before the first frame update
    void Start()
    {
        CRT = gameObject.GetComponentInParent<CrtCrt>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CRT.Tap) { Debug.Log("tap"); }
        else if (CRT.Swipe) { Debug.Log("swipe"); }
    }
}
