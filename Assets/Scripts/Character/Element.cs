using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    public float speed { get; protected set; }
    public float attack { get; protected set; }
    public float defence { get; protected set; }
    public float endurance { get; protected set; }

    public abstract void MoveA();
    public abstract void MoveB();
}
