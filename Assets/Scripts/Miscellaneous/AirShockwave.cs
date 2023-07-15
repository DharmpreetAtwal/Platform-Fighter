using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShockwave : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float scaleSpeed = 50;

        Vector3 scaleIncrm =
            new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed *Time.deltaTime);
        gameObject.transform.localScale += scaleIncrm;

        if(gameObject.transform.localScale.x > 20)
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