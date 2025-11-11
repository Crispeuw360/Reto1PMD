using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    private float timer = 0;
    public GameObject basuraprefab;
    public float altura;
    public float xmin;
    public float navidad;
    public float frequency;
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= frequency)
        {
            timer = 0;
            float x = Random.Range(-xmin, navidad);
            Vector3 position = new Vector3(x, altura, 0);
            Quaternion rotation = new Quaternion();
            
            Instantiate(basuraprefab, position, rotation);

        }

    }
}
