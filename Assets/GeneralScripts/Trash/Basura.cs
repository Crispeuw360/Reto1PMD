using Unity.VisualScripting;
using UnityEngine;


public class Basura : MonoBehaviour
{
    public int puntos = 10;
    [SerializeField] private Sprite s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;
    private SpriteRenderer Trender;
    void Awake()
    {
        Trender = gameObject.GetComponent<SpriteRenderer>();
        int skin = Random.Range(1, 13);
        switch (skin)
        {
            case 1:
                Trender.sprite = s1;
                break;
            case 2:
                Trender.sprite = s2;
                break;
            case 3:
                Trender.sprite = s3;
                break;
            case 4:
                Trender.sprite = s4;
                break;
            case 5:
                Trender.sprite = s5;
                break;
            case 6:
                Trender.sprite = s6;
                break;
            case 7:
                Trender.sprite = s7;
                break;
            case 8:
                Trender.sprite = s8;
                break;
            case 9:
                Trender.sprite = s9;
                break;
            case 10:
                Trender.sprite = s10;
                break;
            case 11:
                Trender.sprite = s11;
                break;
            case 12:
                Trender.sprite = s12;
                break;
            default:
                Trender.sprite = s1;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
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


