using System;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private PlatformEffector2D myEffector;
    public GameObject player;
    private MovimientoPJ movpj;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myEffector = GetComponent<PlatformEffector2D>();
        myEffector.surfaceArc = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && player.GetComponent<MovimientoPJ>().canRun)
        {
            myEffector.surfaceArc = 180;
        }
        else
        {
            myEffector.surfaceArc = 0;
        }
    }
}
