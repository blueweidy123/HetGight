
using UnityEngine;

public class camFollow : MonoBehaviour
{
 //   public GameObject Cam;
    public Transform target;
    public GameObject LockBaseGround;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
 
    private void LateUpdate()
    {
        if(target.transform.position.y >= 0f)
        {
            Camfollow();
        }else if(target.transform.position.y < 0f)
        {
            lockBaseGround();
        }
    }
    void Camfollow()
    {
        Vector3 LockX = target.position;
        LockX.x = 0f;
        Vector3 targetREPL = LockX;
        //------------------------
        Vector3 desPos = targetREPL + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desPos, smoothSpeed);
        transform.position = smoothPos;
    }
    void lockBaseGround()
    {
        Vector3 LockX = LockBaseGround.transform.position;
        LockX.x = 0f;
        Vector3 targetREPL = LockX;
        //------------------------
        Vector3 desPos = targetREPL + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desPos, smoothSpeed);
        transform.position = smoothPos;
    }
}
