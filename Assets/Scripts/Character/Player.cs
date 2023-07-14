using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private void Awake()
    {
        base.Init(gameObject.AddComponent<Air>(), 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = (5 * element.Speed) * Time.deltaTime * Input.GetAxis("Horizontal");
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
        yield return new WaitForSeconds(element.CooldownADuration);
        IsCooldownA = false;
    }

    public override void Jump() { IsJumping = true; ApplyForce(0, 14); }

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
