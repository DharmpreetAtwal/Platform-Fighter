﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private SpriteRenderer SpriteRen { get; set; }

    public bool IsLookingRight { get; protected set; }
    public bool IsJumping { get; protected set; }
    public bool IsCooldownA { get; protected set; }
    public bool IsCooldownB { get; protected set; }

    private Element _element;
    public Element Element {
        get { return _element; }
        set { _element = value; }
    }
    private float _health;
    public float Health
    {
        get { return _health; }
        set
        {
            if (value > 0) { _health = value; }
            else { _health = 0; }
        }
    }
    private float _stamina;
    public float Stamina
    {
        get { return _stamina; }
        set { if (value > 0) { _stamina = value; } else { _stamina = 0; }}
    }

    private void Awake()
    {
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
        IsLookingRight = true;
        IsJumping = false;
        IsCooldownA = false;
        IsCooldownB = false;
        UpdateSprite();
        InvokeRepeating(nameof(RecoverStamina), 0.0f, 0.1f);
    }

    public void Init(Element elem, float health, float stamina)
    {
        _element = elem;
        _health = health;
        _stamina = stamina;
        Awake();
    }

    private void UpdateSprite()
    {
        if (_element.GetType() == typeof(Air))
        { SpriteRen.color = Color.white; }
        else if (_element.GetType() == typeof(Earth))
        { SpriteRen.color = Color.green; }
        else if (_element.GetType() == typeof(Fire))
        { SpriteRen.color = Color.red; }
        else if (_element.GetType() == typeof(Water))
        { SpriteRen.color = Color.blue; }
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
        _health -= (dmg / _element.Defence);
        if(_health <= 0) { Destroy(gameObject); }
    }

    public void RecoverStamina()
    {
        if(_stamina < 100)
        {
            _stamina += 1 * _element.Endurance;
        }
    }

    public abstract void Jump();

}
