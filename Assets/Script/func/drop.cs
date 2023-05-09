using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 0.06f);
    }
}
