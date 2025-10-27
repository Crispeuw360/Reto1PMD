using System.Diagnostics;
using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    [Range(1f, 20f)] public float speed = 10f;
    [Range(1f, 20f)] public float jumpForce = 8f; private Rigidbody2D myRigidbody;
    private BoxCollider2D collision;
    public bool climbing = false;
    public bool grounded = false;
    private Vector2 input;
    private SpriteRenderer mySpriteRenderer;

    public float regular_gravity=1;
    public float lowJumpMult = 2f;
    public float fallMult = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;

        // Recogemos el input del jugador
        playerInput.x = Input.GetAxis("Horizontal") * 10f;

        // Recordamos la velocidad vertical del Rigidbody
        playerInput.y = myRigidbody.linearVelocity.y;

        // Si pulsamos saltar
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            // Nos da igual la velocidad vertical anterior, ahora queremos que vaya para arriba
            playerInput.y = 5f;
        } else if (Input.GetButton("Jump") && grounded== false && myRigidbody.linearVelocity.y<0)
        {
            myRigidbody.gravityScale = regular_gravity - 0.8f;
            if (myRigidbody.gravityScale < 0)
            {
                myRigidbody.gravityScale = 0;
            }
        }
        else
        {
            myRigidbody.gravityScale = regular_gravity;
        }
        if ((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && climbing == true)
        {
            // Nos da igual la velocidad vertical anterior, ahora queremos que vaya para arriba
            playerInput.y = 5f;
        }
        // Asignamos los inputs recogidos al rigidbody
        myRigidbody.linearVelocity = playerInput;
        if (playerInput.x < 0f)
        {
            // Miramos hacia la izquierda
            mySpriteRenderer.flipX = false;
        }

        // Si vamos hacia la derecha
        if (playerInput.x > 0f)
        {
            // Miramos hacia la derecha
            mySpriteRenderer.flipX = true;
        }
    }
    void OnTriggerStay(Collision2D collision)
    {
        if (collision.collider.tag == "vine")
        {
            myRigidbody.gravityScale = 0;
            climbing = true;
        }
    }
    void OnTriggerExit(Collision2D collision)
    {
        if (collision.collider.tag == "vine")
        {
            myRigidbody.gravityScale = 1;
            climbing = false;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.collider.tag == "Floor")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = false;
        }
    }

}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovimientoPJ : MonoBehaviour
{
    private Vector2 input;


    private float movHorizontal = 0f;

    [SerializeField] private float VelMov;

    private Vector3 velocidad = Vector3.zero;

    [SerializeField] private float fuerzaSalto;
    private bool salto = false;
    [SerializeField] private bool grounded = false;

    [SerializeField] private float velEscal;
    private BoxCollider2D collision;
    private float gravedadInicial;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        gravedadInicial = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {


        input.y = Input.GetAxisRaw("Vertical");
        input.x = Input.GetAxisRaw("Horizontal");

        movHorizontal = input.x * VelMov;

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

    }
    private void FixedUpdate()
    {
        grounded = collision.tag == "Floor";
        Mover(movHorizontal * Time.deltaTime, salto);
        Escalar();


        salto = false;
    }
    
private void Mover(float mover, bool salto)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, myRigidbody.linearVelocity.y);

        if (grounded && salto)
        {
            myRigidbody.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

private void Escalar()
    {
        if (input.y !=0 && _isClimbing)
        {
            Vector2 velocidadSubida = new Vector2(myRigidbody.linearVelocity.x, input.y * velEscal);
            myRigidbody.linearVelocity = velocidadSubida;
            
        }

        
    }
}
*/