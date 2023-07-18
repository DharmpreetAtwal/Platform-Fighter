using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendableGround : Obstacle
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Earth earth = collision.collider.gameObject.GetComponent<Earth>();
        if(earth != null)
        {
            earth.PlatformEnabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Earth earth = collision.collider.gameObject.GetComponent<Earth>();
        if (earth != null)
        {
            earth.PlatformEnabled = false;
        }
    }

}
