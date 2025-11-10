using UnityEngine;

public class SFXControl : MonoBehaviour
{

    public static SFXControl instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
    public void PararSonido()
    {
        audioSource.Stop();
    }
}
