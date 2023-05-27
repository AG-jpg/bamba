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
    public SproteRenderer sp;

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
}
