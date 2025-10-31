using UnityEngine;

public class TradeCan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D collider2D)
{
    if (collider2D.tag == "Player" )
        {
            if (Input.GetKey(KeyCode.E))
            {
                switch (gameObject.name)
                {
                    case "Tradecan1":
                        collider2D.GetComponent<MovimientoPJ>().canClimb = true;
                        break;
                    case "Tradecan2":
                        collider2D.GetComponent<MovimientoPJ>().canFly = true;
                        break;
                    case "Tradecan3":
                        collider2D.GetComponent<MovimientoPJ>().canRun = true;
                        break;
                    case "Tradecan4":
                        collider2D.GetComponent<MovimientoPJ>().canHit = true;
                        break;
                    case "Tradecan5":
                        collider2D.GetComponent<MovimientoPJ>().toxMask = true;
                        break;
                    case "Tradecan6":
                        collider2D.GetComponent<MovimientoPJ>().shield = true;
                        break;
                }
                
                
            }
    }
}
}
