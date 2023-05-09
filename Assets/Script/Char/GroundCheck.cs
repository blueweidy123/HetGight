
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public CharacterController player;

    void Start()
    {
        player = gameObject.GetComponentInParent<CharacterController>();
    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundTree" || collision.tag == "basePlatf")
        {
            player.grounded = true;
        }
        if(collision.tag == "tree-Wall")
        {
            if(collision.name == "r")
            {
                player.MovLeft = true;
                player.MovRight = false;
            }
            else if(collision.name == "l")
            {
                player.MovRight = true;
                player.MovLeft = false;
            }
        }
        if(collision.tag == "JumpB")
        {
            player.meetJumpBase = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "GroundTree" || collision.tag == "basePlatf")
        {
            player.grounded = true;
        }
        if (collision.tag == "tree-Wall")
        {
            if (collision.name == "r")
            {
                player.MovLeft = true;
                player.MovRight = false;
            }
            else if (collision.name == "l")
            {
                player.MovRight = true;
                player.MovLeft = false;
            }
        }
        if (collision.tag == "JumpB")
        {
            player.meetJumpBase = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GroundTree" || collision.tag == "basePlatf")
        {
            player.grounded = false;
        }
        if (collision.tag == "tree-Wall")
        {
            player.HoldTree = false;
        }
        if (collision.tag == "tree-Wall")
        {
            if (collision.name == "r")
            {
                player.MovLeft = true;
                player.MovRight = false;
            }
            else if (collision.name == "l")
            {
                player.MovRight = true;
                player.MovLeft = false;
            }
        }
        if (collision.tag == "JumpB")
        {
            player.meetJumpBase = false;
        }
    }
}

