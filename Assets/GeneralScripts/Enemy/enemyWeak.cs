using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyWeak : MonoBehaviour
{
    [SerializeField] private AudioClip OnHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        UISkillUpdate Green= GameObject.FindGameObjectWithTag("GSkill").GetComponent<UISkillUpdate>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (collision.collider.tag == "Player")
        {
            if (collision.collider.GetComponent<MovimientoPJ>().canHit)
            {
                collision.collider.GetComponent<MovimientoPJ>().EnemyHit();
                if (sceneName == "Mundo2")
                {
                    collision.collider.GetComponent<MovimientoPJ>().haskey = true;
                }
                SFXControl.instance.EjecutarSonido(OnHit);
                GameObject padre = this.transform.parent.gameObject;
                padre.SetActive(false);
                Green.UseSkill();
                this.gameObject.SetActive(false);
            }
        }

    }
}
