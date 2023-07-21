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
        CheckCharacterExit(collision);
    }

    protected void CheckCharacterExit(Collision2D collision)
    {
        Character chr = collision.collider.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            StartCoroutine(MoveLowerLayer());
            chr.IsJumping = true;
        }
    }

    private IEnumerator MoveLowerLayer()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.layer = 3;
    }

}
