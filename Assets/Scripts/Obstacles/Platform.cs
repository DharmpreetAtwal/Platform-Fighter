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
            if (chr.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                chr.IsJumping = false;
            }
        }
    }

    protected void CheckCharacterEnter(Collider2D collision)
    {
        Character chr = collision.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            if (chr.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                chr.IsJumping = false;
            }
        }
    }
}
