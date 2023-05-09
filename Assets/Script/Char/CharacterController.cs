
using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 40f;                                              public bool grounded;
    public float maxVel = 4f;                                              public bool jump;
    public float jumpForce = 825f;                                         public bool HoldTree;                                
    private Touch touch;                                                   public bool meetJumpBase;
    public bool gameStarted = false;                                       public bool fastGr;
    public bool hurt, dead = false;
    public int hp = 2;public menucontrol menucrt;
    

    public SwipeDec CRT;
    public bool MovLeft, MovRight;

    [SerializeField] private Rigidbody2D rb;
    private Animator anim;

    void start()
    {
        CRT = gameObject.GetComponentInParent<SwipeDec>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
            if (!gameStarted)
        {
            if (grounded)
            {
                if (CRT.Tap)
                {
                    gameStarted = true;
                    MovRight = true;
                }
            }
        }
        if(hp == 0)
        {
            dead = true;
        }

        CheckGroundOrNot();
        anim.SetBool("jump", jump);
        anim.SetBool("grounded", grounded);
        anim.SetBool("fastGr", fastGr);
        if (hurt)
        {
            rb.velocity = Vector2.zero;
            anim.SetTrigger("hurt");
            hurt = false;
        }
        if (dead)
        {
            anim.SetTrigger("dead");
            StartCoroutine("wait4sec");
            menucrt.loadGameover();
        }

        float velocity = rb.velocity.y;
        if(velocity > 13)
        {
            rb.velocity = new Vector2(0, 10f);
        }

    }

    void FixedUpdate()
    {
        if (gameStarted && !dead)
        {
            HandleMoving();
            HandleJumping();
            handleFastLanding();
        }
    }
    IEnumerator wait4sec()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void HandleMoving()
    {
        float forcex = 0f;
            if (grounded)
            {
                if (MovRight)
                {
                    forcex = speed;
                    Vector3 flip = transform.localScale;
                    flip.x = 1f;
                    transform.localScale = flip;
                    anim.SetBool("run", true);
                }
                else if (MovLeft)
                {
                    forcex = -speed;
                    Vector3 flip = transform.localScale;
                    flip.x = -1f;
                    transform.localScale = flip;
                    anim.SetBool("run", true);
                }
                else
                {
                    anim.SetBool("run", false);
                }

            }
        float velo = Mathf.Abs(rb.velocity.x);
        if (velo < maxVel)
            {
                rb.AddForce(new Vector2(forcex, 0));
            }
    }
    void HandleJumping()
    {
        if (grounded)
        {
                if (CRT.Tap)
                {
                    rb.AddForce(Vector2.up * jumpForce);
                    rb.AddForce(new Vector2(20f, 0));
                }
        }
        if (meetJumpBase)
        {
            if(CRT.Tap)
            {
                rb.AddForce(Vector2.up * jumpForce * 0.75f);
                if (rb.velocity.x > 0)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
        }
    }
    void handleFastLanding()
    {
        if (!grounded)
        {
            if (CRT.SwipeDown || CRT.SwipeUp)
            {
                jump = false;
                fastGr = true;
                rb.AddForce(Vector2.down * (jumpForce / 2));
            }
        }
        if (grounded)
        {
            fastGr = false;
            jump = false;
        }
    }
    void CheckGroundOrNot()
    {
        if (grounded)
        {
            jump = false;
        }else if (!grounded)
        {
           jump = true;
        }
    }
}
