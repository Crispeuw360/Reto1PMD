using UnityEngine;

public class Door2 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<Door>().open)
        {
            Color curcol = this.GetComponent<SpriteRenderer>().color;
            curcol.a = 0;
            this.GetComponent<SpriteRenderer>().color = curcol;
        }
    }
}
