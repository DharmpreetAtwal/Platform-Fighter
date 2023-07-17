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
    private Vector2 _velocity;
    public Vector2 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
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
        _velocity = new Vector2(0, 0);
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

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy")
            || collision.collider.CompareTag("Player"))
        {
            Character enemy =
                collision.collider.gameObject.GetComponent<Character>();
            enemy.TakeDamage(Damage);
            enemy.ApplyForce(_velocity.x * _knockback, _velocity.y * _knockback);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        float transX = _velocity.x * Time.deltaTime;
        float transY = _velocity.y * Time.deltaTime;

        transform.position += new Vector3(transX, transY);
    }

    public static Projectile ShootProjectile(Character shooter, GameObject prefab,
        float x, float y)
    {
        Transform trans = shooter.gameObject.transform;
        Vector3 offsetPosition = trans.position + new Vector3(x, y);
        GameObject ball = Instantiate(prefab, offsetPosition, trans.rotation);

        Projectile proj = ball.GetComponent<Projectile>();
        proj.Velocity = new Vector2(x * proj._speed, y * proj._speed);
        proj.Damage *= shooter.Element.Attack;
        proj.Owner = shooter;

        float angleRotate = Mathf.Rad2Deg * Mathf.Atan2(y, x);
        ball.transform.Rotate(new Vector3(0, 0, angleRotate - 90));

        return proj;
    }
}
