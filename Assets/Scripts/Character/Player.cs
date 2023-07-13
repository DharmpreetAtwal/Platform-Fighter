using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public new void Awake()
    {
        element = new Air();
        Health = 100;
        CooldownADuration = 2.0f;
        CooldownBDuration = 1.0f;
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = 5 * Time.deltaTime * Input.GetAxis("Horizontal");
        gameObject.transform.position += new Vector3(translateX, 0);

        if(translateX > 0)
        {
            IsLookingRight = true;
        } else if(translateX < 0)
        {
            IsLookingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && !IsJumping)
        {
            Jump();
        } else if (Input.GetKeyDown(KeyCode.E) && !IsCooldownA)
        {
            element.MoveA(transform);
            StartCoroutine(StartCooldownA());
        }
    }

    private IEnumerator StartCooldownA()
    {
        IsCooldownA = true;
        yield return new WaitForSeconds(CooldownADuration);
        IsCooldownA = false;
    }

    public override void Jump() { IsJumping = true; ApplyForce(0, 10); }

    public int GetDirection()
    {
        int dir = 1;
        if (!IsLookingRight)
        {
            dir = -1;
        }

        return dir;
    }
}
