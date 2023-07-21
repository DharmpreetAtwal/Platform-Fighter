using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryCollider : MonoBehaviour
{
    private float _xOffset;
    public float XOffset
    {
        get { return _xOffset; }
        private set { _xOffset = value; }
    }
    private float _yOffset;
    public float MyProperty
    {
        get { return _yOffset; }
        private set { _yOffset = value; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character chr = gameObject.GetComponentInParent<Character>();
        if (chr.IsParrying)
        {
            Projectile proj = collision.collider.gameObject.GetComponent<Projectile>();
            if (proj != null)
            {
                Destroy(proj.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Character chr = gameObject.GetComponentInParent<Character>();

        if (chr != null)
        {
            float xOffset = chr.GetDirectionX() * 1.2f;
            float yOffset = chr.GetDirectionY() * 2.0f;
            if (xOffset != 0 || yOffset != 0)
            {
                gameObject.transform.localPosition = new Vector3(xOffset, yOffset);
            } else
            {
                xOffset = -1.2f;
                gameObject.transform.localPosition = new Vector3(xOffset, yOffset);
            }
            float angleRotate = Mathf.Rad2Deg * Mathf.Atan2(yOffset, xOffset);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, angleRotate);
        }
    }
}
