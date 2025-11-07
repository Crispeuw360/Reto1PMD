using Unity.VisualScripting;
using UnityEngine;

public class Boton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
             UnityEngine.Debug.Log("Empienza boton");

            GameObject door = GameObject.FindGameObjectWithTag("door");
            door.GetComponent<Door>().open = true;

            Color currcol = door.GetComponentInChildren<SpriteRenderer>().color;
            currcol.a = 0;
            door.GetComponentInChildren<SpriteRenderer>().color = currcol;
            UnityEngine.Debug.Log("acaba boton");

        }
    }
}
