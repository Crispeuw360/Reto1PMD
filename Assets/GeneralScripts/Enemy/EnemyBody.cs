using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBody : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            MovimientoPJ Player = collision.collider.GetComponent<MovimientoPJ>();
            if (Player.shield)
            {
                Vector2 direction = transform.position - collision.transform.position;
                direction.Normalize();
                collision.collider.GetComponent<Rigidbody2D>().AddForce(direction * 20f, ForceMode2D.Impulse);
                Player.shield = false;
            }
            else
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);

            }
        }

    }
}
