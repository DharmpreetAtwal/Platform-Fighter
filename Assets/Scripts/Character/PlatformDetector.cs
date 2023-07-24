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
            GameObject chr = gameObject.GetComponentInParent<Character>().gameObject;
            chr.layer = flr.gameObject.layer;
        }
    }

    private void Update()
    {
        GameObject chr = gameObject.GetComponentInParent<Character>().gameObject;
        if(chr == null) { Destroy(gameObject); }
        else
        {
            transform.position = chr.transform.position + new Vector3(0, -1.5f);
        }
    }
}