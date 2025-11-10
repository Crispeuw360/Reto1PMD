using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPJ : MonoBehaviour
{
    [Range(1f, 20f)] public float speed = 10f;
    [Range(1f, 20f)] public float jumpForce = 8f; private Rigidbody2D myRigidbody;
    [SerializeField] private AudioClip climbSFX;
    private BoxCollider2D collision;
    public bool haskey = false;
    public bool climbing = false;
    public bool grounded = false;
    public bool canRun;
    public bool canClimb;
    public bool toxMask;
    public bool canHit;
    public bool shield;
    public bool canFly;
    private Vector2 input;
    private SpriteRenderer mySpriteRenderer;

    private Transform child;
    private Animator animator;
    public float regular_gravity = 1;
    public float lowJumpMult = 2f;
    public float fallMult = 2.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        child = transform.Find("Animacion");
        animator = child.GetComponent<Animator>();
        mySpriteRenderer = child.GetComponent<SpriteRenderer>();
        Scene currentScene = SceneManager.GetActiveScene();
        UnityEngine.Debug.Log("SCENE IS:");
        UnityEngine.Debug.Log(currentScene.name);
        // Obtiene el nombre de la escena
        string sceneName = currentScene.name;
        toxMask = false;
        shield = false;
        if (sceneName == "Mundo1")
        {
            canRun = false;
            canHit = false;
            canFly = false;
            canClimb = false;
        }
        else
        {
            canClimb = true;
            canFly = true;
            if (sceneName == "Mundo3")
            {
                canRun = true;
                canHit = true;
            }
            else
            {
                canHit = false;
                canRun = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;

        // Recogemos el input del jugador
        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            animator.SetBool("IsRunning", true);
            playerInput.x = Input.GetAxis("Horizontal") * 10f;
        }
        else
        {
            animator.SetBool("IsRunning", false);
            playerInput.x = Input.GetAxis("Horizontal") * 6f;
        }
        // Recordamos la velocidad vertical del Rigidbody
        playerInput.y = myRigidbody.linearVelocity.y;

        // Si pulsamos saltar
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            // Nos da igual la velocidad vertical anterior, ahora queremos que vaya para arriba
            playerInput.y = 5f;
        }
        else if (Input.GetButton("Jump") && grounded == false && myRigidbody.linearVelocity.y < 0)
        {
            if (canFly)
            {
                animator.SetBool("IsFlying", true);
                myRigidbody.gravityScale = regular_gravity - 0.8f;
                if (myRigidbody.gravityScale < 0)
                {
                    myRigidbody.gravityScale = 0;
                }
            }
        }
        else
        {
            animator.SetBool("IsFlying", false);
            myRigidbody.gravityScale = regular_gravity;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && climbing == true)
        {
            // Nos da igual la velocidad vertical anterior, ahora queremos que vaya para arriba
            playerInput.y = 5f;
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && climbing == true)
        {
            playerInput.y = -5f;
        }
        else if (climbing == true)
        {
            playerInput.y = 0;
        }
        // Asignamos los inputs recogidos al rigidbody
        myRigidbody.linearVelocity = playerInput;
        if (playerInput.x < 0f) // Miramos hacia la dercha
        {
            animator.SetBool("IsWalking", true);
            mySpriteRenderer.flipX = false;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.8f, 0.2f);
        }
        else if (playerInput.x > 0f) // Si vamos hacia la izquierda
        {

            animator.SetBool("IsWalking", true);
            mySpriteRenderer.flipX = true;
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0.8f, 0.2f);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    public void EnterNadar()
    {

        myRigidbody.gravityScale = 0.5f;
        regular_gravity = 0.5f;
        // _animator.SetTrigger("Climb");
        UnityEngine.Debug.Log("Entro en agua");
    }

    public void ExitNadar()
    {
        myRigidbody.gravityScale = 1f;
        regular_gravity = 1f;
        // _animator.SetTrigger("ExitClimb");
        UnityEngine.Debug.Log("Salio del agua");
    }
    public void MoveStair()
    {
        climbing = true;
        SFXControl.instance.EjecutarSonido(climbSFX);
        myRigidbody.gravityScale = 0f;
        regular_gravity = 0f;
        animator.SetBool("IsClimbing", true);
        UnityEngine.Debug.Log("Entro en una escalera");
    }

    public void ExitStair()
    {
        SFXControl.instance.PararSonido();
        climbing = false;
        myRigidbody.gravityScale = 1f;
        regular_gravity = 1f;
        animator.SetBool("IsClimbing", false);
        UnityEngine.Debug.Log("Salio de una escalera");
    }
    public void EnemyHit()
    {
        UnityEngine.Debug.Log("EnemyHit1");
        animator.SetBool("OnHit", true);

        animator.SetBool("OnHit", false);
    }
    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.collider.tag == "Floor")
        {
            animator.SetBool("IsFlying", false);
            grounded = true;

        }
        if (collision.collider.name == "MovingPlatform")
        {
            transform.SetParent(collision.collider.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {

            grounded = false;
        }
        if (collision.collider.name == "MovingPlatform")
        {
            transform.SetParent(null);
        }
    }


}
