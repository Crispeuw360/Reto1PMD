using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    public float velocidad;
    private float jumps;
    private bool grounded=true;
    private Rigidbody2D myRigidbody;
    private Collision2D collision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collision2D>();
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
        if (Input.GetButtonDown("Jump")&& grounded)
        {
	        // Nos da igual la velocidad vertical anterior, ahora queremos que vaya para arriba
            playerInput.y = 5f;
        }
		
		// Asignamos los inputs recogidos al rigidbody
        myRigidbody.linearVelocity = playerInput;
        OnCollisionStay2D(collision);
        OnCollisionExit2D(collision);
    }
    void OnCollisionStay2D(Collision2D collision)
        {
	        if (collision.collider.tag == "Floor")
	        {
	            grounded = true;
	        }
        }
        // En collision exit no hace falta hacer la comprobación
        void OnCollisionExit2D(Collision2D collision)
        {
            grounded = false;
        }
}
