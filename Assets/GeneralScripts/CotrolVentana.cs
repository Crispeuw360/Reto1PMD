using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonStart : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameStart()
    {
        SceneManager.LoadScene("Mundo1", LoadSceneMode.Single);
    }
}
