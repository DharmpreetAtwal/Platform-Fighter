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
        gameObject.transform.position += new Vector3(translateX, 0);
        float inputY = Input.GetAxis("Vertical");

        if (translateX > 0) { IsLookingRight = true; noneXInput = false; }
        else if(translateX < 0) { IsLookingRight = false; noneXInput = false; }
        else { noneXInput = true; }

        if(inputY > 0) { IsLookingUp = true; noneYInput = false; }
        else if(inputY < 0) { IsLookingUp = false; noneYInput = false; }
        else { noneYInput = true; }

        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping) {  Jump(); }

        if (Input.GetMouseButtonDown(0) && !IsCooldownA)
        {
            Element.MoveA(transform);
            StartCoroutine(StartCooldownA());
        }

        if (Input.GetMouseButtonDown(1) && !IsCooldownB)
        {
            Element.MoveB(transform);
            StartCoroutine(StartCooldownB());
        }

        MainUIManager.Instance.UpdateStaminaBar(Stamina, MaxStamina);
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

    public override void Jump() { IsJumping = true; ApplyForce(0, 150); }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        MainUIManager.Instance.UpdateHealthBar(Health, MaxHealth);
    }

}
