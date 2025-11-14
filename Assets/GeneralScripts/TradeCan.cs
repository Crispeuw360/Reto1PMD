using UnityEngine;
using TMPro;

public class TradeCan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip Obtain;
    [SerializeField] private TextMeshProUGUI textcan;
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
                            textcan.text="You can now climb vines with [w]/[s] or [up]/[down]";
                        }

                        break;
                    case "Tradecan2":
                        if (!player.canFly)
                        {
                            if (controlador.puntuacion >= 15)
                            {
                                Blue.Unlock();
                                controlador.IncrementarPuntuacion(-15);
                                
                                SFXControl.instance.EjecutarSonido(Obtain);
                                player.canFly = true;
                                textcan.text="You can now glide while holding [Space]";
                            } else
                            {
                                textcan.text="You need 15 trash";
                            }
                        }
                        break;
                    case "Tradecan3":
                        if (!player.canRun)
                        {
                            if (controlador.puntuacion >= 25)
                            {
                                orange.Unlock();
                                controlador.IncrementarPuntuacion(-25);
                                player.canRun = true;
                                SFXControl.instance.EjecutarSonido(Obtain);
                                textcan.text="You can now run (and run on water) while holding [L shift]";
                            } else
                            {
                                textcan.text="You need 25 trash";
                            }
                        }
                        break;
                    case "Tradecan4":
                        if (!player.canHit)
                        {
                             if (controlador.puntuacion >= 10)
                            {
                                Green.Unlock();
                                controlador.IncrementarPuntuacion(-10);
                                player.canHit = true;
                                SFXControl.instance.EjecutarSonido(Obtain);
                                textcan.text="You can now dispose of enemies by jumping on them";
                            } else
                            {
                                textcan.text="You need 10 trash";
                            }
                        }
                        break;
                    case "Tradecan5":
                        if (!player.toxMask)
                        {
                             if (controlador.puntuacion >= 30)
                            {
                            Red.Unlock();
                            controlador.IncrementarPuntuacion(-30);
                            player.toxMask = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                            textcan.text="You can now survive in toxic waste";
                            }else
                            {
                                textcan.text="You need 30 trash";
                            }
                        }
                        break;
                    case "Tradecan6":
                        if (!player.shield)
                        {
                             if (controlador.puntuacion >= 5)
                            {
                            Yellow.Unlock();
                            controlador.IncrementarPuntuacion(-5);
                            player.shield = true;
                            SFXControl.instance.EjecutarSonido(Obtain);
                            textcan.text="You can now survive one hit from enemies  (5 trash to regain shield)";
                            }else
                            {
                                textcan.text="you need 5 trash";
                            }
                        }
                        break;
                }


            }
        }
    }
}
