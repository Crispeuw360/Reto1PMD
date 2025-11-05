using UnityEngine;
using UnityEngine.SceneManagement;

public class Froms1tos2 : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
                Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;
                if (sceneName == "Mundo1")
                {
                        SceneManager.LoadScene("Mundo2", LoadSceneMode.Single);
                }
                else if (sceneName == "Mundo2" && collider2D.GetComponent<MovimientoPJ>().haskey)
                {
                        SceneManager.LoadScene("Mundo3", LoadSceneMode.Single);
                }
        }
}
