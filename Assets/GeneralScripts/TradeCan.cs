using UnityEngine;

public class TradeCan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip Obtain;
    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            MovimientoPJ player = collider2D.GetComponent<MovimientoPJ>();
            if (Input.GetKey(KeyCode.E))
            {

                switch (gameObject.name)
                {
                    case "Tradecan1":
                        if (!player.canClimb)
                        {
                            SFXControl.instance.EjecutarSonido(Obtain);
                            player.canClimb = true;
                        }

                        break;
                    case "Tradecan2":
                        if (!player.canFly)
                        {
                            SFXControl.instance.EjecutarSonido(Obtain);
                            player.canFly = true;
                        }
                        break;
                    case "Tradecan3":
                        if (!player.canRun)
                        {
                            player.canRun = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                        }
                        break;
                    case "Tradecan4":
                        if (!player.canHit)
                        {
                            player.canHit = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                        }
                        break;
                    case "Tradecan5":
                        if (!player.toxMask)
                        {
                            player.toxMask = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                        }
                        break;
                    case "Tradecan6":
                        if (!player.shield)
                        {
                            player.shield = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                        }
                        break;
                }


            }
        }
    }
}
