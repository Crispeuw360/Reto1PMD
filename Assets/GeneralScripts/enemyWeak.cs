using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyWeak : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (collision.collider.tag == "Player")
        {
            if (collision.collider.GetComponent<MovimientoPJ>().canHit)
            {
                if (sceneName == "Mundo2")
                {
                    collision.collider.GetComponent<MovimientoPJ>().haskey = true;
                }
                GameObject padre = this.transform.parent.gameObject;
                padre.SetActive(false);

                this.gameObject.SetActive(false);
            }
        }

    }
}
