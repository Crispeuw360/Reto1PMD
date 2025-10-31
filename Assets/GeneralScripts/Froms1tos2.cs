using UnityEngine;
using UnityEngine.SceneManagement;

public class Froms1tos2 : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D collider2D)
{
        SceneManager.LoadScene("Mundo2", LoadSceneMode.Single);
}
}
