using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Element
{
    private void Awake()
    {
        float spd = 2.0f;
        float atk = 5.0f;
        float def = 5.0f;
        float end = 10.0f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;

        base.Init(spd, atk, def, end, coolADur, coolBDur, moveACost, moveBCost);
    }

    public override void MoveA(Transform trans)
    {
        Player player = trans.gameObject.GetComponent<Player>();

        if(MoveAStaminaCost <= player.Stamina)
        {
            player.Stamina -= MoveAStaminaCost;
            int dir = player.GetDirection();

            Vector3 offsetPosition = trans.position + new Vector3(2 * dir, 0);
            GameObject ball = Instantiate(GameManager.Instance.airBallPrefab,
                offsetPosition, trans.rotation);

            ball.GetComponent<AirBall>().Speed *= dir;
            ball.GetComponent<AirBall>().Damage *= Attack;
            ball.GetComponent<AirBall>().Owner = player;
        }
    }

    public override void MoveB(Transform trans)
    {
        throw new System.NotImplementedException();
    }
}
