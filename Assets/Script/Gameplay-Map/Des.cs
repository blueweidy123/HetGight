
using UnityEngine;

public class Des : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player.transform.position.y - transform.position.y > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
