using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendableGround : Platform
{
    // Landing straight on top of BendableGround, collision works correctly.
    // Running across Bendable ground going from Platform -> BendableGround,
    // collision doesn't work correctly.

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCharacterEnter(collision);
        Earth earth = collision.collider.gameObject.GetComponent<Earth>();
        if(earth != null)
        {
            earth.PlatformEnabled = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        Earth earth = collision.collider.gameObject.GetComponent<Earth>();
        if (earth != null)
        {
            earth.PlatformEnabled = false;
        }
    }

}
