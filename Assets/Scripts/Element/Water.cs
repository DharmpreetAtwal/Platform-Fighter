using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    void Start()
    {
        float spd = 1.0f;
        float atk = 0.75f;
        float def = 1.5f;
        float end = 2.0f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 1.0f;
        float moveBK = 10.0f;

        GameObject pref = GameManager.Instance.waterBallPrefab;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

    public override void MoveMouseOne(Transform trans, int index)
    {
        MoveA(trans);
    }

    public override void MoveMouseTwo(Transform trans, int index)
    {
        MoveB(trans);
    }

    public override void MoveShift(Transform trans, int index)
    {
        StartCoroutine(IcicleFury(trans));
    }

    private IEnumerator IcicleFury(Transform trans)
    {
        for(int i=0; i < 4; i++)
        {
            Character shooter = trans.gameObject.GetComponent<Character>();
            float x = 2 * shooter.GetDirectionX();
            float y = 2 * shooter.GetDirectionY();

            Vector3 offsetPosition = trans.position + new Vector3(x, y);
            GameObject icicle = Instantiate(GameManager.Instance.waterIcicle,
                offsetPosition, trans.rotation);

            float angleRotate = Mathf.Rad2Deg * Mathf.Atan2(y , x);
            icicle.transform.Rotate(new Vector3(0, 0, angleRotate - 90));

            Projectile proj = icicle.GetComponent<Projectile>();
            proj.Velocity = new Vector2(x * proj.Speed, y * proj.Speed);
            proj.Damage *= Attack;
            proj.Owner = shooter;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
