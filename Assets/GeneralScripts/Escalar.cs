using UnityEngine;

public class Escalar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
private void OnTriggerEnter2D(Collider2D collider2D)
{
    if (collider2D.tag == "Player")
    {
        collider2D.GetComponent<MovimientoPJ>().MoveStair();
    }
}

private void OnTriggerExit2D(Collider2D collider2D)
{
    if (collider2D.tag == "Player")
    {
        collider2D.GetComponent<MovimientoPJ>().ExitStair();
    }
}
}
