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
        //float spd = 0.75f;
        //float atk = 1.0f;
        //float def = 2.0f;
        //float end = 1.5f;
        float spd = 2.0f;
        float atk = 1.0f;
        float def = 0.75f;
        float end = 1.5f;

        float coolADur = 0.25f;
        float coolBDur = 1.0f;
        float moveACost = 20;
        float moveBCost = 20;
        float moveAK = 10.0f;
        float moveBK = 100.0f;

        GameObject pref = GameManager.Instance.earthBallPrefab;
        _platformCooldownDur = 4;
        _platformStaminaCost = 50;

        base.Init(spd, atk, def, end, coolADur, coolBDur,
            moveACost, moveBCost, pref, moveAK, moveBK);
    }

    public override IEnumerator MoveMouseOne(Transform trans, int index)
    {
        yield return new WaitForSeconds(0.12f);
        MoveA(trans);
    }

    public override IEnumerator MoveMouseTwo(Transform trans, int index)
    {
        yield return new WaitForSeconds(0.12f);
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
            float x = 2 * shooter.LastXInput;
            float y = 2 * shooter.LastYInput;

            if (shooter.Stamina >= _platformStaminaCost)
            {
                shooter.Stamina -= _platformStaminaCost;
                Vector3 pos = trans.position + new Vector3(0, -1.0f); ;
                Instantiate(GameManager.Instance.earthPlatform, pos,
                    trans.rotation);
            }
        }
    }
}
