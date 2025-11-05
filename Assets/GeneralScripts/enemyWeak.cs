using Unity.VisualScripting;
using UnityEngine;

public class enemyWeak : MonoBehaviour
{
   
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<MovimientoPJ>().haskey=true;
             GameObject padre = this.transform.parent.gameObject;
            padre.SetActive(false);

            this.gameObject.SetActive(false);
        }

    }
}
