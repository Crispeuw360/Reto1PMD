using UnityEngine;

public class Vines : MonoBehaviour
{
    private Collider2D collider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider2D= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(collider2D);
        OnTriggerExit2D(collider2D);
    }
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
