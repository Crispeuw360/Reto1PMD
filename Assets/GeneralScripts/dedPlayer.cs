using UnityEngine;
using UnityEngine.SceneManagement;

public class dedPlayer : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        
    }
}
