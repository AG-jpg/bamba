using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Vector2 direction;
    private CinemachineVirtualCamera cm;
    private GrayCamera gc;
    private SpriteRenderer sprite;
    private Vector2 damageDirection;

    [Header ("Stadistics")]
    public float movementSpeed = 10;
    public float jumpForce = 5;
    public int vidas = 5;
    public float ImmortalTime;
    public int vidasRestantes;

    [Header ("Collisions")]
    public Vector2 down;
    public float radiusDetection;
    public LayerMask FloorLayer;
    

    [Header ("Booleans")]
    public bool canMove = true;
    public bool stepping = true;
    public bool floorStep;
    public bool Immortal;
    public bool applyForce;

    [Header ("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip slam;
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip snow;
    [SerializeField] private AudioClip stone;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cm = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        gc = Camera.main.GetComponent<GrayCamera>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        if(vidas > 0)
        return;

        this.enabled = false;
        SceneManager.LoadScene(2);
    }

    public void RecibirDano()
    {
        StartCoroutine(DamageImpact(Vector2.zero));
    }

    public void RecibirDano(Vector2 damageDirection)
    {
        StartCoroutine(DamageImpact(damageDirection));
    }

    private IEnumerator DamageImpact(Vector2 damageDirection)
    {
        if(!Immortal)
        {
            StartCoroutine(Immortalities());
            vidas--;
            gc.enabled = true;
            float AuxiliarSpeed = movementSpeed;
            this.damageDirection = damageDirection;
            applyForce = true;
            Time.timeScale = 0.4f;
            yield return new WaitForSeconds(0.2f);
            Time.timeScale = 1;
            gc.enabled = false;

            for(int i = GameManager.instance.vidasUI.transform.childCount -1; i >= 0; i--)
            {
                if(GameManager.instance.vidasUI.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    GameManager.instance.vidasUI.transform.GetChild(i).gameObject.SetActive(false);
                    break;
                }
            }

            movementSpeed = AuxiliarSpeed;
            Die();
        }
    }

    private void FixedUpdate() 
    {
        if(applyForce)
        {
            movementSpeed = 0;
            rb.velocity = Vector2.zero;
            rb.AddForce(-damageDirection * 25, ForceMode2D.Impulse);
            applyForce = false;
        }
    }

    public void Immortality()
    {
        StartCoroutine(Immortalities());
    }

    private IEnumerator Immortalities()
    {
        Immortal = true;

        float passedTime = 0;

        while (passedTime < ImmortalTime)
        {
            sprite.color = new Color(1, 1, 1, .5f);
            yield return new WaitForSeconds(ImmortalTime / 20);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(ImmortalTime / 20);
            passedTime += ImmortalTime / 10;
        }

        Immortal = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(jump);
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

    //Sounds
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Coin"))
        {
           audioSource.PlayOneShot(coin);
        }
        else if(collision.CompareTag("Snowball"))
        {
            audioSource.PlayOneShot(snow);
        }
        else if(collision.CompareTag("Stone"))
        {
            audioSource.PlayOneShot(stone);
        }
        else if(collision.CompareTag("Snowman"))
        {
            audioSource.PlayOneShot(slam);
        }
        else if(collision.CompareTag("Golem"))
        {
            audioSource.PlayOneShot(slam);
        }
    }
}