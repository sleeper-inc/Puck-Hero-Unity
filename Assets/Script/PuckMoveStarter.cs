

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PuckMoveStarter : MonoBehaviour
{



    // Start is called before the first frame update

    public puck p;

    void Start()
    {
        p.enabled = false;
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        p.enabled = true;
    }


}
