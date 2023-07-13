using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private SpriteRenderer SpriteRen { get; set; }

    public bool IsLookingRight { get; protected set; }
    public bool IsJumping { get; protected set; }
    public bool IsCooldownA { get; protected set; }
    public bool IsCooldownB { get; protected set; }

    public Element element { get; protected set; }
    private float _health;
    public float Health
    {
        get { return _health; }
        set
        {
            if (value > -1) { _health = value; }
            else { _health = 0; }
        }
    }

    public void Awake()
    {
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
        IsLookingRight = true;
        IsJumping = false;
        IsCooldownA = false;
        IsCooldownB = false;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (element.GetType() == typeof(Air))
        {
            SpriteRen.color = Color.white;
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
            IsJumping = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        _health -= dmg;
        if(_health == 0) { Destroy(gameObject); }
    }

    public abstract void Jump();

}
