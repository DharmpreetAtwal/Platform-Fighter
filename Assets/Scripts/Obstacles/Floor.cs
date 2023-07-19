using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        Character chr = collision.collider.gameObject.GetComponent<Character>();
        if (chr != null)
        {
            gameObject.layer = 3;
            chr.IsJumping = true;
        }
    }
}
