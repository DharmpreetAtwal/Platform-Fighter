using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public new void Awake()
    {
        this.element = new Air();
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = 5 * Time.deltaTime * Input.GetAxis("Horizontal");
        gameObject.transform.position += new Vector3(translateX, 0);

        if(translateX > 0)
        {
            this.isLookingRight = true;
        } else if(translateX < 0)
        {
            this.isLookingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && !this.isJumping)
        {
            Jump();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            element.MoveA(this.transform);
        } 
    }

    public override void Jump() { this.isJumping = true; ApplyForce(0, 10); }

    public int GetDirection()
    {
        int dir = 1;
        if (!this.isLookingRight)
        {
            dir = -1;
        }

        return dir;
    }
}
