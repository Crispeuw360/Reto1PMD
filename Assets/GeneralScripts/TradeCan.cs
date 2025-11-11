using UnityEngine;

public class TradeCan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip Obtain;

    private ControlPuntos controlador;
    void Awake()
    {
        controlador = GameObject.FindGameObjectWithTag("Hud").GetComponent<ControlPuntos>();
    }
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
                            if (controlador.puntuacion > 15)
                            {
                                controlador.IncrementarPuntuacion(-15);
                                
                                SFXControl.instance.EjecutarSonido(Obtain);
                                player.canFly = true;
                            } else
                            {
                                UnityEngine.Debug.Log("Necesitas recoger al menos 15 de basura");
                            }
                        }
                        break;
                    case "Tradecan3":
                        if (!player.canRun)
                        {
                            if (controlador.puntuacion > 25)
                            {
                                controlador.IncrementarPuntuacion(-25);
                                player.canRun = true;
                                SFXControl.instance.EjecutarSonido(Obtain);
                            } else
                            {
                                UnityEngine.Debug.Log("Necesitas recoger al menos 25 de basura");
                            }
                        }
                        break;
                    case "Tradecan4":
                        if (!player.canHit)
                        {
                             if (controlador.puntuacion > 10)
                            {
                                controlador.IncrementarPuntuacion(-10);
                                player.canHit = true;
                                SFXControl.instance.EjecutarSonido(Obtain);
                            } else
                            {
                                UnityEngine.Debug.Log("Necesitas recoger al menos 10 de basura");
                            }
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
