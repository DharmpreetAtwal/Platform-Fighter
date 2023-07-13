using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        protected set
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

    protected SpriteRenderer SpriteRen { get; private set; }

    public void Awake()
    {
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(WaitDestroy());
    }

    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(TimeDestroy);
        Destroy(gameObject);
    }

    public abstract void OnCollisionEnter2D(Collision2D collision);

}
