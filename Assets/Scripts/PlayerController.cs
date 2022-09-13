using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Vector2 direction;

    [Header ("Stadistics")]
    public float movementSpeed = 10;
    public float jumpForce = 5;
    public float dashSpeed = 20;

    [Header ("Collisions")]
    public Vector2 down;
    public float radiusDetection;
    public LayerMask FloorLayer;
    

    [Header ("Booleans")]
    public bool canMove = true;
    public bool stepping = true;
    public bool canDash;
    public bool doingDash;
    public bool floorStep;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Anchor();
    }

    private void Dash(float x, float y)
    {
        anim.SetBool("Dash", true);
        Vector3 playerPosition = Camera.main.WorldToViewportPoint(transform.position);
        Camera.main.GetComponent<RippleEffect>().Emit(playerPosition);
        
        canDash = true;
        rb.velocity = Vector2.zero;
        rb.velocity += new Vector2(x, y).normalized * dashSpeed;
        StartCoroutine(prepareDash());
    }

    private IEnumerator prepareDash()
    {
        StartCoroutine(floorDash());
        rb.gravityScale = 0;
        doingDash = true;

        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = 1;
        doingDash = false;
        endDash();
    }

    private IEnumerator floorDash()
    {
        yield return new WaitForSeconds(0.15f);
        if(stepping)
        {
            canDash = false;
        }
    }

    public void endDash()
    {
        anim.SetBool("Dash", false);
    }

    private void touchFloor()
    {
        canDash = false;
        doingDash = false;
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");

        direction = new Vector2(x, y);

        Walk();
        improvedJump();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(stepping)
            {
                Jump();
            }
        } 

        if(Input.GetKeyDown(KeyCode.X) && !doingDash)
         {
            if(xRaw != 0 || yRaw != 0)
            {
                Dash(xRaw, yRaw);
            }
         }

        if(stepping && !floorStep)
        {
            touchFloor();
            floorStep = true;
        }

        if(!stepping && floorStep)
        {
            stepping = false;
        }
    }

    private void improvedJump()
    {

        
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.0f - 1) * Time.deltaTime;
        }
    }

    private void Anchor()
    {
        stepping = Physics2D.OverlapCircle((Vector2)transform.position + down, radiusDetection, FloorLayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }

    private void Walk()
    {
        if(canMove && !doingDash)
        {
            rb.velocity = new Vector2(direction.x * movementSpeed, rb.velocity.y);

            if(direction != Vector2.zero)
            {
                if(!stepping)
                {
                    anim.SetBool("Standing", true);
                }
                else
                {
                    anim.SetBool("Walk", true);
                }
                if(direction.x < 0 && transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                } else if(direction.x > 0 && transform.localScale.x < 0)
                {
                     transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            } else
            {
                anim.SetBool("Walk", false);
            }
        }
        
    }
}
