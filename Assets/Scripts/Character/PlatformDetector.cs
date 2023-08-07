using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Platform flr = collision.gameObject.GetComponent<Platform>();
        if (flr != null)
        {
            Character chr = gameObject.GetComponentInParent<Character>();
            if(chr != null)
            {
                chr.gameObject.layer = flr.gameObject.layer;
            }
        }
    }

    private void Update()
    {
        if (gameObject.GetComponentInParent<Character>() != null)
        {
            GameObject chr = gameObject.GetComponentInParent<Character>().gameObject;
            if (chr == null) { Destroy(gameObject); }
        }
    }
}