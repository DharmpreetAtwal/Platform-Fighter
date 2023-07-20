using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Character chr = collision.collider.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            chr.IsJumping = false;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        Character chr = collision.collider.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            gameObject.layer = 3;
            chr.IsJumping = true;
        }
    }

}
