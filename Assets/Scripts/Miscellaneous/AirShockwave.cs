using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShockwave : MonoBehaviour
{
    private float _scaleSpeed = 50;
    private float _scaleMax = 20;

    // Update is called once per frame
    void Update()
    {
        Vector3 scaleIncrm =
            new Vector3(_scaleSpeed * Time.deltaTime, _scaleSpeed * Time.deltaTime);
        gameObject.transform.localScale += scaleIncrm;

        if(gameObject.transform.localScale.x > _scaleMax)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Projectile proj = collision.collider.gameObject.GetComponent<Projectile>();

        if (proj != null)
        {
            Destroy(proj.gameObject);
        }
    }
}