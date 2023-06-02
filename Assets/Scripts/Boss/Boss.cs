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
    public bool applyForce;
    private bool shaking;
    private bool spawnActive;
    private int attackCount = 0;
    public bool isKO;
    public int actualPhase = 1;
    public int vidas;
    public string bossName;

    [Header("References")]
    public GameObject bullet;
    public Transform attackPoint;
    public GameObject snowman;
    public GameObject spawner;

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
                Instantiate(snowman, spawner.transform.GetChild(i).transform.position, Quaternion.identity);
            }
        }
    }

    public void Shake()
    {
        if (attackCount == 3)
        {
            StartCoroutine(KnockOut());
        }
    }

    private IEnumerator KnockOut()
    {
        isKO = true;
        anim.SetBool("Stun", true);
        yield return new WaitForSeconds(3);
        isKO = false;
        anim.SetBool("Stun", false);
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

        GameObject go = Instantiate(bullet, (Vector2).attackPoint.transform.position + (Vector2.right * 3 * transform.localScale.x), Quaternion.identity);

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
        anim.SetFloat("distance", distance);

        if (MaxLife / 3 >= vidas)
        {
            actualPhase = 3;
        }
        else if (2 * MaxLife / 3 >= vidas)
        {
            actualPhase = 2;
        }

        ManagePhase(actualPhase);
    }

    private void CambiarVista(float direccionX)
    {
        if (direccionX < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (direccionX > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void Die()
    {
        if (vidas <= 0)
        {
            rb.velocity = Vector2.zero;
            Destroy(gameObject, 0.2f);
        }
    }

}
