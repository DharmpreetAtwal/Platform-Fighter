using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCharacterEnter(collision);
    }

    protected void CheckCharacterEnter(Collision2D collision)
    {
        Character chr = collision.collider.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            chr.IsJumping = false;
        }
    }
}
