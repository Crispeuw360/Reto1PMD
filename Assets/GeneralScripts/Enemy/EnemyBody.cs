using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBody : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        UISkillUpdate Yellow= GameObject.FindGameObjectWithTag("YSkill").GetComponent<UISkillUpdate>();
        if (collision.collider.tag == "Player")
        {
            MovimientoPJ Player = collision.collider.GetComponent<MovimientoPJ>();
            if (Player.shield)
            {
                Vector2 direction = transform.position - collision.transform.position;
                direction.Normalize();
                collision.collider.GetComponent<Rigidbody2D>().AddForce(direction * 40f, ForceMode2D.Impulse);
                Yellow.UseSkill();
                Player.shield = false;
                Yellow.SpendSkill();
            }
            else
            {
                GameOver.SetActive(true);
                Time.timeScale = 0;
                
            }
        }

    }
}
