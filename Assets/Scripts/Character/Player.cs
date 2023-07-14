using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Awake()
    {
        Element elem = gameObject.GetComponent<Element>();

        base.Init(elem, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = (5 * Element.Speed) * Time.deltaTime * Input.GetAxis("Horizontal");
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
            Element.MoveA(transform);
            StartCoroutine(StartCooldownA());
        } else if (Input.GetKeyDown(KeyCode.Q) && !IsCooldownB)
        {
            Element.MoveB(transform);
            StartCoroutine(StartCooldownB());
        }

        MainUIManager.Instance.UpdateStaminaBar(Stamina);
    }

    private IEnumerator StartCooldownA()
    {
        IsCooldownA = true;
        yield return new WaitForSeconds(Element.CooldownADuration);
        IsCooldownA = false;
    }

    private IEnumerator StartCooldownB()
    {
        IsCooldownB = true;
        yield return new WaitForSeconds(Element.CooldownBDuration);
        IsCooldownB = false;
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
