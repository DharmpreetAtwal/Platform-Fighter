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

        if (Input.GetKeyDown(KeyCode.W) && !this.isJumping)
        {
            Jump();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            element.MoveA();
        } 
    }

    public override void Jump() { this.isJumping = true; ApplyForce(0, 10); }

}
