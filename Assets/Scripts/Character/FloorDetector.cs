using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Floor flr = collision.collider.gameObject.GetComponent<Floor>();
        if(collision.collider.CompareTag("Floor"))
        {
            // Move FloorDetector to 0 as well?
            flr.gameObject.layer = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Floor flr = collision.collider.gameObject.GetComponent<Floor>();
        if (flr != null)
        {
            flr.gameObject.layer = 3;
        }
    }

    private void Update()
    {
        GameObject chr = gameObject.GetComponentInParent<Character>().gameObject;
        if(chr == null) { Destroy(gameObject); }
        else
        {
            transform.position = chr.transform.position + new Vector3(0, -1.2f);
        }
    }
}
