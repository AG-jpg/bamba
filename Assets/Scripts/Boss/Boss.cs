using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public PlayerController player;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public SpriteRenderer sp;

    private CinemachineVirtualCamera cm;
    private ImpactArea impact;

    private MonoBehaviour actualState;
    public MonoBehaviour chaseState;
    public MonoBehaviour attackState;

    [HideInInspector]
    public float distance;
    private bool CanShoot;
    private int MaxLife;

    [Header("Stadistics")]
    public float detectionArea;
    public float attackArea;
    public float speedMovement;
    public bool isAttacking;
    private bool shaking;
    private bool spawnActive;
    private int attackCount = 0;
    public bool isKO = false;
    public bool IsPaused;
    public int actualPhase = 1;
    public int vidas;
    public string bossName;

    [Header("References")]
    public GameObject bullet;
    public GameObject platform;
    public Transform attackPoint;
    public GameObject attackTrigger;
    public GameObject snowman;
    public GameObject spawner;
    public GameObject snow;
    public GameObject dialogueBox;

    [Header("Audio")]
    public AudioSource audioSource;
    [SerializeField] private AudioClip victory;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cm = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        sp = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        impact = transform.GetChild(0).GetComponent<ImpactArea>();
        MaxLife = vidas;
        gameObject.name = bossName;
        IsPaused = false;
    }

    public void ActivateState(MonoBehaviour newState)
    {
        if (actualState != null)
        {
            actualState.enabled = false;
        }

        actualState = newState;
        actualState.enabled = true;
    }

    private void ManagePhase(int phase)
    {
        switch (phase)
        {
            case 2:
                if (!spawnActive)
                {
                    StartCoroutine(Spawner());
                }
                break;
        }
    }

    private IEnumerator Spawner()
    {
        spawnActive = true;

        while (true)
        {
            yield return new WaitForSeconds(5);
            for (int i = 0; i < spawner.transform.childCount; i++)
            {
                Instantiate(snowman, (Vector2)spawner.transform.GetChild(i).transform.position, Quaternion.identity);
            }
        }
    }

    public void Shake()
    {
        impact.SetMakesDamage(true);
        attackCount++;
        if (attackCount == 3)
        {
            StartCoroutine(KnockOut());
        }
    }

    private IEnumerator KnockOut()
    {
        isKO = true;
        anim.SetBool("Stunt", true);
        attackTrigger.SetActive(false);
        yield return new WaitForSeconds(3);
        isKO = false;
        anim.SetBool("Stunt", false);
        attackTrigger.SetActive(true);
        attackCount = 0;
    }

    public void CreateBullet()
    {
        if (actualPhase == 3)
        {
            StartCoroutine(BulletsCreate());
        }
    }

    private IEnumerator BulletsCreate()
    {
        CanShoot = false;
        Vector2 posicion = new Vector2(attackPoint.transform.position.x,
        attackPoint.transform.position.y - attackArea);

        GameObject go = Instantiate(bullet, (Vector2)attackPoint.transform.position +
        (Vector2.right * 3 * transform.localScale.x), Quaternion.identity);

        float angle = 45;
        if (transform.localScale.x < 0)
        {
            angle = 135;
        }

        go.GetComponent<Rigidbody2D>().velocity =
        new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)).normalized * 8;

        yield return new WaitForSeconds(3);
        CanShoot = true;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        anim.SetFloat("Distance", distance);

        if (MaxLife / 3 >= vidas)
        {
            actualPhase = 3;
        }
        else if (2 * MaxLife / 3 >= vidas)
        {
            actualPhase = 2;
        }

        ManagePhase(actualPhase);
        Die();

        if (IsPaused)
        {
            TakeAction();
        }
    }

    public void RecibirDano()
    {
        if (vidas > 0)
        {
            StartCoroutine(DamageImpact());
        }

    }

    private void Die()
    {
        if (vidas <= 0)
        {
            IsPaused = true;
            Destroy(spawner);
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetBool("Stunt", true);
            dialogueBox.SetActive(true);
            Destroy(attackTrigger);
        }
    }

    private void TakeAction()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiate(snow, transform.position, transform.rotation);
            Destroy(gameObject, 0.5f);
            Destroy(dialogueBox);
            platform.SetActive(true);
            IsPaused = false;
        }
    }

    private IEnumerator DamageImpact()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public void Movement(float d)
    {
        if (d <= attackArea)
        {
            ActivateState(attackState);
        }
        else
        {
            if (!isAttacking)
            {
                ActivateState(chaseState);
            }
        }
    }

    public void DeactivateAttack()
    {
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionArea);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackArea);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            RecibirDano();
            vidas--;
        }
    }
}
