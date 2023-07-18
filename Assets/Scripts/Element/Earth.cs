using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
    private bool _platformEnabled;
    public bool PlatformEnabled
    {
        get { return _platformEnabled; }
        set { _platformEnabled = value; }
    }

    public float _platformCooldownDur;
    public float PlatformCooldownDur
    {
        get { return _platformCooldownDur; }
        private set { _platformCooldownDur = value; }
    }
    public float _platformStaminaCost;
    public float PlatformStaminaCost
    {
        get { return _platformStaminaCost; }
        private set { _platformStaminaCost = value; }
    }

    // Awake is called before the first frame update
    void Start()
    {
        float spd = 0.75f;
        float atk = 1.0f;
        float def = 2.0f;
        float end = 1.5f;

        float coolADur = 0.0f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 1.0f;
        float moveBK = 10.0f;

        GameObject pref = GameManager.Instance.earthBallPrefab;
        _platformCooldownDur = 4;
        _platformStaminaCost = 30;

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
        CooldownSDuration = _platformCooldownDur;
        MoveSStaminaCost = _platformStaminaCost;
        Platform(trans);
    }

    private void Platform(Transform trans)
    {
        if (_platformEnabled)
        {
            Character shooter = trans.gameObject.GetComponent<Character>();
            float x = 2 * shooter.GetDirectionX();
            float y = 2 * shooter.GetDirectionY();

            if (shooter.Stamina >= _platformStaminaCost)
            {
                Vector3 pos = trans.position + new Vector3(0, -3); ;
                Instantiate(GameManager.Instance.earthPlatform, pos,
                    trans.rotation);
            }
        }
    }
}
