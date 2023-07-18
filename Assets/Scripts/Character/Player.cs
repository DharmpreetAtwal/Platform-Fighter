using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Awake()
    {
        Element elem = gameObject.GetComponent<Element>();
        float maxHealth = 100;
        float health = 100;
        float maxStam = 100;
        float stamina = 100;

        base.Init(elem, maxHealth, health, maxStam, stamina);
    }

    private void Start()
    {
        MainUIManager.Instance.UpdateHealthBar(Health, MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = (5 * Element.Speed) * Time.deltaTime * Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (translateX > 0) { IsLookingRight = true; NoneXInput = false; }
        else if (translateX < 0) { IsLookingRight = false; NoneXInput = false; }
        else { NoneXInput = true; }

        if (inputY > 0) { IsLookingUp = true; NoneYInput = false; }
        else if (inputY < 0) { IsLookingUp = false; NoneYInput = false; }
        else { NoneYInput = true; }

        if (IsMovementEnabled)
        {
            gameObject.transform.position += new Vector3(translateX, 0);

            if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
            { Jump(); }

            if (Input.GetMouseButtonDown(0) && !IsCooldownA)
            {
                StartCoroutine(Element.MoveMouseOne(transform, 0));
                StartCoroutine(StartCooldownA());
            }

            if (Input.GetMouseButtonDown(1) && !IsCooldownB)
            {
                StartCoroutine(Element.MoveMouseTwo(transform, 0));
                StartCoroutine(StartCooldownB());
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && !IsCooldownS)
            {
                Element.MoveShift(transform, 0);
                StartCoroutine(StartCooldownShift());
            }

            if (Input.GetKeyDown(KeyCode.E))
            { ChangeElement(); UpdateSprite(); }

            MainUIManager.Instance.UpdateStaminaBar(Stamina, MaxStamina);
        }
    }

    public override void Jump() { IsJumping = true; ApplyForce(0, 1000); }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        MainUIManager.Instance.UpdateHealthBar(Health, MaxHealth);
    }

    private void ChangeElement()
    {
        Element elm = gameObject.GetComponent<Element>();

        if (typeof(Air) == elm.GetType())
        {
            Element = gameObject.AddComponent<Earth>();
        } else if (typeof(Earth) == elm.GetType())
        {
            Element = gameObject.AddComponent<Fire>();
        } else if (typeof(Fire) == elm.GetType())
        {
            Element = gameObject.AddComponent<Water>();
        } else if (typeof(Water) == elm.GetType())
        {
            Element = gameObject.AddComponent<Air>();
        }

        Destroy(elm);
    }

}
