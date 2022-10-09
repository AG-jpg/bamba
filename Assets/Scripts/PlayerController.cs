using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Vector2 direction;
    private CinemachineVirtualCamera cm;
    private AudioSource jumpfx;

    [Header ("Stadistics")]
    public float movementSpeed = 10;
    public float jumpForce = 5;

    [Header ("Collisions")]
    public Vector2 down;
    public float radiusDetection;
    public LayerMask FloorLayer;
    

    [Header ("Booleans")]
    public bool canMove = true;
    public bool stepping = true;
    public bool floorStep;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cm = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Anchor();
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
                jumpfx.Play();
            }
        } 

        if(stepping && !floorStep)
        {

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
        if(canMove)
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
