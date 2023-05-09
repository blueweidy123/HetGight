
using UnityEngine;

public class followcam : MonoBehaviour
{
    public GameObject cam;

    public Vector3 offset = new Vector3();

    void Update()
    {
        InvokeRepeating("folCam", 0, 0);
        
    }
    void folCam()
    {
        transform.position = cam.transform.position + offset;
    }
}
