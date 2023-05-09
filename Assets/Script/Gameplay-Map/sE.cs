
using UnityEngine;

public class sE : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject playerPos;
    public GameObject acornSPP;
    public GameObject acornPrefab;
    private CharacterController Gm;


    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating("acornDrop", Random.Range(5, 5), Random.Range(5, 10));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 campos = mainCam.transform.position;
        campos.y += 6f;
        campos.z = playerPos.transform.position.z;
        acornSPP.transform.position = campos;
    }
    void acornDrop()
    {
        Vector3 rdXcoord = acornSPP.transform.position;
        float rd = Random.Range(0, 2f);
        int r = Random.Range(1, 3);
        if (r > 1)
        {
            rdXcoord.x += rd;
        }else if(r < 2)
        {
            rdXcoord.x -= rd;
        }
        acornSPP.transform.position = rdXcoord;
        Instantiate(acornPrefab, acornSPP.transform.position, acornSPP.transform.rotation);
            
    
        
    }
}
