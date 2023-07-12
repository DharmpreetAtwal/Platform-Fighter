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
    public bool isJumping { get; protected set; }
    protected Element element;

    public void Awake()
    {
        this.spriteRen = gameObject.GetComponent<SpriteRenderer>();
        this.isJumping = false;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (element.GetType() == typeof(Air))
        {
            this.spriteRen.color = Color.white;
        }
    }

    public void ApplyForce(float x, float y)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(
            new Vector3(x, y), ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            this.isJumping = false;
        }
    }

    public abstract void Jump();

}
