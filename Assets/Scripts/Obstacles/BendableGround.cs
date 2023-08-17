using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendableGround : Platform
{
    // Landing straight on top of BendableGround, collision works correctly.
    // Running across Bendable ground going from Platform -> BendableGround,
    // collision doesn't work correctly.

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Character chr = collision.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            if (!chr.IsJumping) { CheckCharacterEnter(collision); }
        }

        Earth earth = collision.gameObject.GetComponent<Earth>();
        if (earth != null)
        {
            earth.PlatformEnabled = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        Earth earth = collision.gameObject.GetComponent<Earth>();
        if (earth != null)
        {
            earth.PlatformEnabled = false;
        }
    }

}
