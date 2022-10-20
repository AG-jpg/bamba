using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Snowman : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private CinemachineVirtualCamera cm;
    private bool aplicarFuerza;

    public float distanciaDeteccionJugador = 6;
    public float distanciaDeteccionFlecha = 5;
    public GameObject flecha;
    public float fuerzaLanzamiento = 5;
    public float velocidadMovimiento;
    public bool lanzandoFlecha;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        cm = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Snowman";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccion = (player.transform.position - transform.position).normalized * distanciaDeteccionFlecha;
        Debug.DrawRay(transform.position, direccion, Color.red);

        float distanciaActual = Vector2.Distance(transform.position, player.transform.position);

        if(distanciaActual <= distanciaDeteccionFlecha)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("Walking", false);

            Vector2 direccionNormalizada = direccion.normalized;
            CambiarVista(direccionNormalizada.x);

            if(!lanzandoFlecha)
            {
                StartCoroutine(LanzarFlecha(direccion, distanciaActual));
            }else
            {
                if(distanciaActual <= distanciaDeteccionJugador)
                {
                    Vector2 movimiento = new Vector2(direccion.x, 0);
                    movimiento = movimiento.normalized;
                    rb.velocity = movimiento * velocidadMovimiento;
                    anim.SetBool("Walking", true);
                    CambiarVista(movimiento.x);
                } else
                {
                    anim.SetBool("Walking", false);
                }
            }
        }
    }

    private void CambiarVista(float direccionX)
        {
            if(direccionX < 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }else if(direccionX > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeteccionJugador);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaDeteccionFlecha);
    }

    private IEnumerator LanzarFlecha(Vector2 direccionFlecha, float distancia)
    {
        lanzandoFlecha = true;
        anim.SetBool("Disparando", true);
        yield return new WaitForSeconds(1.42f);
        anim.SetBool("Disparando", false);
        direccionFlecha = direccionFlecha.normalized;

        GameObject flechaGo = Instantiate(flecha, transform.position, Quaternion.identity);
        flechaGo.transform.GetComponent<Snowball>().direccionFlecha = direccionFlecha;
        flechaGo.transform.GetComponent<Snowball>().snowman = this.gameObject;

        flechaGo.transform.GetComponent<Rigidbody2D>().velocity = direccionFlecha * fuerzaLanzamiento;
        lanzandoFlecha = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Daño al jugador player.RecibirDaño((transform.position - player.transform.position).normalized);
        }
    }

    private void FixedUpdate() 
    {
        if(aplicarFuerza)
        {
            rb.AddForce((transform.position - player.transform.position).normalized * 100, ForceMode2D.Impulse);
            aplicarFuerza = false;
        }    
    }
}
