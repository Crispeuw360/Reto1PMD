using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPJ : MonoBehaviour
{
    [Range(1f, 20f)] public float speed = 10f;
    [Range(1f, 20f)] public float jumpForce = 8f; private Rigidbody2D myRigidbody;
    private BoxCollider2D collision;
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

    public float regular_gravity=1;
    public float lowJumpMult = 2f;
    public float fallMult = 2.5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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
        }else{
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
        if (Input.GetKey(KeyCode.LeftShift)&& canRun)
        {
            playerInput.x = Input.GetAxis("Horizontal") * 10f;
        }
        else
        {
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
                myRigidbody.gravityScale = regular_gravity - 0.8f;
                if (myRigidbody.gravityScale < 0)
                {
                    myRigidbody.gravityScale = 0;
                }
            }
        }
        else
        {
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
    public void EnterNadar()
{
    
    myRigidbody.gravityScale = 0.5f;
    regular_gravity = 0.5f;
   // _animator.SetTrigger("Climb");
    UnityEngine.Debug.Log("Entro en una escalera");
}

public void ExitNadar()
{
    myRigidbody.gravityScale = 1f;
    regular_gravity = 1f;
   // _animator.SetTrigger("ExitClimb");
    UnityEngine.Debug.Log("Salio de una escalera");
}
public void MoveStair()
{
    climbing = true;
    myRigidbody.gravityScale = 0f;
    regular_gravity = 0f;
   // _animator.SetTrigger("Climb");
    UnityEngine.Debug.Log("Entro en una escalera");
}

public void ExitStair()
{
    climbing = false;
    myRigidbody.gravityScale = 1f;
    regular_gravity = 1f;
   // _animator.SetTrigger("ExitClimb");
    UnityEngine.Debug.Log("Salio de una escalera");
}
    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.collider.tag == "Floor")
        {
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
