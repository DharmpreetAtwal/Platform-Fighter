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

    private GameObject _ballPrefab;
    public GameObject BallPrefab
    {
        get { return _ballPrefab; }
        set { _ballPrefab = value; }
    }

    public void MoveA(Transform trans)
    {
        Player player = trans.gameObject.GetComponent<Player>();

        if (MoveAStaminaCost <= player.Stamina)
        {
            player.Stamina -= MoveAStaminaCost;
            int dir = player.GetDirection();

            Vector3 offsetPosition = trans.position + new Vector3(2 * dir, 0);
            GameObject ball = Instantiate(_ballPrefab,
                offsetPosition, trans.rotation);

            ball.GetComponent<Projectile>().Speed *= dir;
            ball.GetComponent<Projectile>().Damage *= Attack;
            ball.GetComponent<Projectile>().Owner = player;
        }
    }

    public abstract void MoveB(Transform trans);

    public void Init(float spd, float atk, float def, float end,
        float coolADur, float coolBDur, float moveACost, float moveBCost,
        GameObject ballPrefab)
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
    }

}
