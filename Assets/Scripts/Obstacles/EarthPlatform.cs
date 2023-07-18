using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPlatform : Obstacle
{
    // If raising platform up, scale +1 = y + (1/2) 
    // If raising pltform sideways, sclae + 1 = y + cos(angle) / 2
    // Update is called once per frame
    private float growthRate = 15.0f;
    private float platformDur = 4.0f;
    private float platformMaxScale = 10.0f;
    private bool maxReached = false;

    void Update()
    {
        gameObject.transform.localScale +=
            new Vector3(0, growthRate * Time.deltaTime);
        gameObject.transform.position +=
            new Vector3(0, (growthRate / 2) * Time.deltaTime);

        if(gameObject.transform.localScale.y > platformMaxScale & !maxReached)
        {
            maxReached = true;
            StartCoroutine(PauseLowerPlatform());
        } else if (gameObject.transform.localScale.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator PauseLowerPlatform()
    {
        growthRate = 0.0f;
        yield return new WaitForSeconds(platformDur);
        growthRate = -15.0f;
    }

}
