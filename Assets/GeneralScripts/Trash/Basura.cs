using Unity.VisualScripting;
using UnityEngine;


public class Basura : MonoBehaviour
{
    public int puntos = 10;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag=="Player")
        {
            
            ControlPuntos controlador = GameObject.FindGameObjectWithTag("Hud").GetComponent<ControlPuntos>();
            if (controlador != null)
            {
                controlador.IncrementarPuntuacion(puntos);
            }
            // Destruir el objeto coleccionable
            Destroy(gameObject);
        }
    }
}


