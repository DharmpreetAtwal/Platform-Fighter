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

    private float _moveADelay;
    public float MoveADelay
    {
        get { return _moveADelay; }
        set { _moveADelay = value; }
    }
    private float _moveBDelay;
    public float MoveBDelay
    {
        get { return _moveBDelay; }
        set { _moveBDelay = value; }
    }

    public abstract void MoveA(Transform trans);
    public abstract void MoveB(Transform trans);
}
