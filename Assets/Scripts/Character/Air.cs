using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    public void Awake()
    {
        speed = 2.0f;
        attack = 1.0f;
        defence = 0.5f;
        endurance = 1.5f;
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
