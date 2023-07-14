using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        set
        {
            if (value > -1) { _damage = value; }
            else { _damage = 0; }
        }
    }
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private float _timeDestroy;
    public float TimeDestroy
    {
        get{ return _timeDestroy; }
        set { if (value >= 0) { _timeDestroy = value; } }
    }
    private float _knockback;
    public float Knockback
    {
        get { return _knockback; }
        set { _knockback = value; }
    }
    private Character _owner;
    public Character Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    protected SpriteRenderer SpriteRen { get; private set; }

    private void Awake()
    {
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(WaitDestroy());
    }

    public void Init(float dmg, float spd, float timeDestroy, float knockb)
    {
        _damage = dmg;
        _speed = spd;
        _timeDestroy = timeDestroy;
        _knockback = knockb;
        Awake();
    }

    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(TimeDestroy);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(Damage);
            enemy.ApplyForce(_speed * _knockback, 0);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0);
    }
}
