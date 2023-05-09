using System.Collections;
using UnityEngine;

public class ObsCheck : MonoBehaviour
{
    public CharacterController player;
    public Renderer rend;
    Color c;
    private void Awake()
    {
        
    }
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }
    void Start()
    {
        player = gameObject.GetComponentInParent<CharacterController>();
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "basePlatf" && collision.gameObject.tag != "tree-Wall"  && collision.gameObject.tag != "GroundTree" && player.hp > 0)
        {
            player.hp -= 1;
            StartCoroutine("getInvul");
        }
    }
    IEnumerator getInvul()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        c.a = 0.5f;
        rend.material.color = c;
        player.hurt = true;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        c.a = 1f;
        rend.material.color = c;


    }
}
