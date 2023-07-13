using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    public void Awake()
    {
        Speed = 2.0f;
        Attack = 1.0f;
        Defence = 0.5f;
        Endurance = 1.5f;

        CooldownADuration = 0.0f;
        CooldownBDuration = 1.0f;
    }

    public override void MoveA(Transform trans)
    {
        Player player = trans.gameObject.GetComponent<Player>();
        int dir = player.GetDirection();

        Vector3 offsetPosition = trans.position + new Vector3(2 * dir, 0);
        GameObject ball = Instantiate(GameManager.Instance.airBallPrefab,
            offsetPosition, trans.rotation);

        ball.GetComponent<AirBall>().Speed *= dir;
        ball.GetComponent<AirBall>().Owner = player;
    }

    public override void MoveB(Transform trans)
    {
        throw new System.NotImplementedException();
    }
}
