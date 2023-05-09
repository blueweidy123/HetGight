
using UnityEngine;

public class MapMov : MonoBehaviour
{
    public GameObject BG;

    private void Start()
    {
        InvokeRepeating("repeat", 20, 20);

    }
    void Update()
    {
        moving();
        
    }
    void moving()
    {
        BG.transform.Translate(Vector2.left * 0.5f * Time.deltaTime);
    }
    void repeat()
    {
        Vector3 repeat = BG.transform.position;
        repeat.x += 10f;
        BG.transform.position = repeat;

    }
    
}
