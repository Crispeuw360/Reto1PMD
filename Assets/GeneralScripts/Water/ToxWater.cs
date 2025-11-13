using UnityEngine;

public class ToxWater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject GameOver;
    private UISkillUpdate Red;
    void Start()
    {
        Red = GameObject.FindGameObjectWithTag("RSkill").GetComponent<UISkillUpdate>();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    
{
    if (collider2D.tag == "Player")
    {
        if (!collider2D.GetComponent<MovimientoPJ>().toxMask)
            {
                GameOver.SetActive(true);
                Time.timeScale = 0;

            }
            else
            {
                Red.UseSkill();
            }
    }
}
    private void OnTriggerExit2D(Collider2D collider2D)
{
    if (collider2D.tag == "Player")
    {
        Red.unUseSkill();
        if (!collider2D.GetComponent<MovimientoPJ>().toxMask)
            {
                Red.SpendSkill();
            }
    }
}

}
