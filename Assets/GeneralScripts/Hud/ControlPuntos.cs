using TMPro;
using UnityEngine;

public class ControlPuntos : MonoBehaviour
{
    
    public TextMeshProUGUI Texto_dinero;
    public int puntuacion = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void IncrementarPuntuacion(int cantidad)
    {
        puntuacion += cantidad;
        Texto_dinero.text = "Basura Recogida: " + puntuacion;
    }

}
