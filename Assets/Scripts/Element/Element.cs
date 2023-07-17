using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private float _attack;
    public float Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }
    private float _defence;
    public float Defence
    {
        get { return _defence; }
        set { _defence = value; }
    }
    private float _endurance;
    public float Endurance
    {
        get { return _endurance; }
        set { _endurance = value; }
    }

    private float _cooldownADuration;
    public float CooldownADuration
    {
        get { return _cooldownADuration; }
        set { _cooldownADuration = value; }
    }
    private float _cooldownBDuration;
    public float CooldownBDuration
    {
        get { return _cooldownBDuration; }
        set { _cooldownBDuration = value; }
    }
    private float _moveAStaminaCost;
    public float MoveAStaminaCost
    {
        get { return _moveAStaminaCost; }
        set { if (value > 0) { _moveAStaminaCost = value; } else { _moveAStaminaCost = value; } }
    }
    private float _moveBStaminaCost;
    public float MoveBStaminaCost
    {
        get { return _moveBStaminaCost; }
        set { if (value > 0) { _moveBStaminaCost = value; } else { _moveBStaminaCost = value; } }
    }
    private float _moveAKnockBack;
    public float MoveAKnockback
    {
        get { return _moveAKnockBack; }
        set { if (value > 0) { _moveAKnockBack = value; } else { _moveAKnockBack = value; } }
    }
    private float _moveBKnockBack;
    public float MoveBKnockback
    {
        get { return _moveBKnockBack; }
        set { if (value > 0) { _moveBKnockBack = value; } else { _moveBKnockBack = value; } }
    }
    private GameObject _ballPrefab;
    public GameObject BallPrefab
    {
        get { return _ballPrefab; }
        set { _ballPrefab = value; }
    }

    public void Init(float spd, float atk, float def, float end,
    float coolADur, float coolBDur, float moveACost, float moveBCost,
    GameObject ballPrefab, float moveAK, float moveBK)
    {
        _speed = spd;
        _attack = atk;
        _defence = def;
        _endurance = end;
        _cooldownADuration = coolADur;
        _cooldownBDuration = coolBDur;
        _moveAStaminaCost = moveACost;
        _moveBStaminaCost = moveBCost;
        _ballPrefab = ballPrefab;
        _moveAKnockBack = moveAK;
        _moveBKnockBack = moveBK;
    }

    public abstract void MoveMouseOne(Transform trans, int index);

    protected void MoveA(Transform trans)
    {
        Character shooter = trans.gameObject.GetComponent<Character>();
        float x = 2 * shooter.GetDirectionX();
        float y = 2 * shooter.GetDirectionY();

        if (MoveAStaminaCost <= shooter.Stamina && (x != 0 || y != 0))
        {
            shooter.Stamina -= MoveAStaminaCost;

            Vector3 offsetPosition = trans.position + new Vector3(x, y);
            GameObject ball = Instantiate(_ballPrefab,
                offsetPosition, trans.rotation);

            Projectile proj = ball.GetComponent<Projectile>();
            proj.Velocity = new Vector2(x * proj.Speed, y * proj.Speed);
            proj.Damage *= Attack;
            proj.Owner = shooter;
            proj.Knockback *= _moveAKnockBack;
        }
    }

    public abstract void MoveMouseTwo(Transform trans, int index);

    protected void MoveB(Transform trans)
    {
        Character shooter = trans.gameObject.GetComponent<Character>();
        float x = 2 * shooter.GetDirectionX();
        float y = 2 * shooter.GetDirectionY();

        if (_moveBStaminaCost <= shooter.Stamina && (x != 0 || y != 0))
        {
            shooter.Stamina -= MoveBStaminaCost;

            Vector3 offsetPosition = trans.position + new Vector3(x, y);
            GameObject ball = Instantiate(_ballPrefab,
                offsetPosition, trans.rotation);

            Projectile proj = ball.GetComponent<Projectile>();
            proj.Velocity = new Vector2(x * proj.Speed, y * proj.Speed);
            proj.Damage *= _attack;
            proj.Owner = shooter;
            proj.Knockback *= _moveBKnockBack;
        }
    }

    public abstract void MoveShift(Transform trans, int index);

}
