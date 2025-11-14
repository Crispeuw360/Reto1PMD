using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject victory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
private void OnTriggerEnter2D(Collider2D collider2D)
{
    if (collider2D.tag == "Player" )
    {
        victory.SetActive(true);
    }
}
}
