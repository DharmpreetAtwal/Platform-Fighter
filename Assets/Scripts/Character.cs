using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health
    {
        get { return health;  }
        set
        {
            if (value > -1) { this.health = value; }
            else { this.health = 0; }
        }
    }
    public SpriteRenderer spriteRen { get; private set; }
    public bool isJumping { get; private set; }

    private void Awake()
    {
        this.spriteRen = gameObject.GetComponent<SpriteRenderer>();
        this.isJumping = false;
    }

    public void ApplyForce(float x, float y)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(
            new Vector3(x, y), ForceMode2D.Impulse);
    }

    public abstract void Jump();

    // Update is called once per frame
    void Update()
    {
        
    }
}
