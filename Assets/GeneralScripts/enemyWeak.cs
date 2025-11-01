using UnityEngine;

public class enemyWeak : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == "Player")
        {
            
            
        }

    }
}
