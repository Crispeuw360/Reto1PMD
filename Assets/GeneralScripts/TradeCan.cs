using UnityEngine;

public class TradeCan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip Obtain;

    private ControlPuntos controlador;
    private GameObject control;

    private UISkillUpdate brown;
    private UISkillUpdate Blue;
    private UISkillUpdate orange;
    private UISkillUpdate Green;
    private UISkillUpdate Red;
    private UISkillUpdate Yellow;
    void Awake()
    {
        control = GameObject.FindGameObjectWithTag("Hud");
        controlador = control.GetComponent<ControlPuntos>();

        brown = GameObject.FindGameObjectWithTag("BrSkill").GetComponent<UISkillUpdate>();
        Blue = GameObject.FindGameObjectWithTag("BlSkill").GetComponent<UISkillUpdate>();
        orange = GameObject.FindGameObjectWithTag("OSkill").GetComponent<UISkillUpdate>();
        Green = GameObject.FindGameObjectWithTag("GSkill").GetComponent<UISkillUpdate>();
        Red = GameObject.FindGameObjectWithTag("RSkill").GetComponent<UISkillUpdate>();
        Yellow = GameObject.FindGameObjectWithTag("YSkill").GetComponent<UISkillUpdate>();
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
                            brown.Unlock();
                            SFXControl.instance.EjecutarSonido(Obtain);
                            player.canClimb = true;
                        }

                        break;
                    case "Tradecan2":
                        if (!player.canFly)
                        {
                            if (controlador.puntuacion > 15)
                            {
                                Blue.Unlock();
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
                                orange.Unlock();
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
                                Green.Unlock();
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
                            Red.Unlock();
                            player.toxMask = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                        }
                        break;
                    case "Tradecan6":
                        if (!player.shield)
                        {
                            Yellow.Unlock();
                            player.shield = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                        }
                        break;
                }


            }
        }
    }
}
