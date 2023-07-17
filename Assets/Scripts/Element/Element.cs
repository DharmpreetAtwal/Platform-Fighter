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
        private set { _cooldownADuration = value; }
    }
    private float _cooldownBDuration;
    public float CooldownBDuration
    {
        get { return _cooldownBDuration; }
        private set { _cooldownBDuration = value; }
    }
    private float _cooldownSDuration;
    public float CooldownSDuration {
        get { return _cooldownSDuration; }
        protected set { _cooldownSDuration = value; }
    }

    private float _moveAStaminaCost;
    public float MoveAStaminaCost
    {
        get { return _moveAStaminaCost; }
        private set { if (value > 0) { _moveAStaminaCost = value; } else { _moveAStaminaCost = value; } }
    }
    private float _moveBStaminaCost;
    public float MoveBStaminaCost
    {
        get { return _moveBStaminaCost; }
        private set { if (value > 0) { _moveBStaminaCost = value; } else { _moveBStaminaCost = value; } }
    }
    private float _moveSStaminaCost;
    public float MoveSStaminaCost
    {
        get { return _moveSStaminaCost; }
        protected set { _moveSStaminaCost = value; }
    }

    private float _moveAKnockBack;
    public float MoveAKnockback
    {
        get { return _moveAKnockBack; }
        private set { if (value > 0) { _moveAKnockBack = value; } else { _moveAKnockBack = value; } }
    }
    private float _moveBKnockBack;
    public float MoveBKnockback
    {
        get { return _moveBKnockBack; }
        private set { if (value > 0) { _moveBKnockBack = value; } else { _moveBKnockBack = value; } }
    }

    private GameObject _ballPrefab;
    public GameObject BallPrefab
    {
        get { return _ballPrefab; }
        private set { _ballPrefab = value; }
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
            Projectile proj = Projectile.ShootProjectile(shooter, _ballPrefab, x, y);
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
            Projectile proj = Projectile.ShootProjectile(shooter, _ballPrefab, x, y);
            proj.Knockback *= _moveBKnockBack;
        }
    }

    public abstract void MoveShift(Transform trans, int index);

}
