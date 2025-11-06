using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Boolean open;
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            this.GetComponent<PlatformEffector2D>().surfaceArc = 0;
        }
    }
}
