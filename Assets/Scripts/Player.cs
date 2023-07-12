using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Update is called once per frame
    void Update()
    {
        float translateX = 5 * Time.deltaTime * Input.GetAxis("Horizontal");
        gameObject.transform.position += new Vector3(translateX, 0);

        if (Input.GetKeyDown(KeyCode.W) && !this.isJumping)
        {
            Jump();
            this.spriteRen.color = Color.red;
        }
    }

    public override void Jump() { ApplyForce(0, 10); }

}
