using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCharacterEnter(collision);
    }

    //protected virtual void OnCollisionExit2D(Collision2D collision)
    //{
    //    CheckCharacterExit(collision);
    //}

    protected void CheckCharacterEnter(Collision2D collision)
    {
        Character chr = collision.collider.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            chr.IsJumping = false;
        }
    }

    //protected void CheckCharacterExit(Collision2D collision)
    //{
    //    Character chr = collision.collider.gameObject.GetComponent<Character>();
    //    if (chr != null)
    //    {
    //        StartCoroutine(MoveLowerLayer(chr));
    //        chr.IsJumping = true;
    //    }
    //}

    //private IEnumerator MoveLowerLayer(Character chr)
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    if (chr != null)
    //    {
    //        chr.gameObject.layer = 0;
    //    }
    //}

}
