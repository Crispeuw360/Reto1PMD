using UnityEngine;
using UnityEngine.Rendering;

public class SFXControl : MonoBehaviour
{

    public static SFXControl instance;
    private AudioSource audioSource;
    private float volumen;

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
        volumen= instance.audioSource.volume;

    }

    public void EjecutarSonido(AudioClip sfx)
    {
        instance.audioSource.volume = volumen;
        instance.audioSource.PlayOneShot(sfx);
    }
     public void soundfly(AudioClip sfx)
    {
        instance.audioSource.volume = volumen / 5; 
        instance.audioSource.PlayOneShot(sfx);
    }
    public void PararSonido()
    {
        audioSource.Stop();
    }
}
