using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Coroutine _comboCoroutine;
    private Coroutine _chargeCoroutine;
    private int _comboMin;
    private int _comboCount;
    private float _comboTimer;

    private void Awake()
    {
        Element elem = gameObject.GetComponent<Element>();

        float maxHealth = 100;
        float health = 100;
        float maxStam = 100;
        float stamina = 100;

        _comboCount = 0;
        _comboTimer = 2.0f;
        _comboMin = 3;

        base.Init(elem, maxHealth, health, maxStam, stamina);
    }

    private void Start()
    {
        MainUIManager.Instance.UpdateHealthBar(Health, MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        float translateX = (Element.Speed) * Time.deltaTime * Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (translateX > 0) { IsLookingRight = true; NoneXInput = false; }
        else if (translateX < 0) { IsLookingRight = false; NoneXInput = false; }
        else { NoneXInput = true; }

        if (inputY > 0) { IsLookingUp = true; NoneYInput = false; }
        else if (inputY < 0) { IsLookingUp = false; NoneYInput = false; }
        else { NoneYInput = true; }

        if(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
        {
            HandleIdleAiming();
        }
        else
        {
            // LastX/YInput cannot be (0, 0)
            int dirX = GetDirectionX();
            int dirY = GetDirectionY();

            if (dirX != 0 || dirY != 0)
            {
                LastXInput = dirX;
                LastYInput = dirY;
            }
        }

        CheckMaxVelocityX();
        if (IsMovementEnabled)
        {
            //if (Input.GetKeyDown(KeyCode.Space) && !IsJumping)
            //{ Jump(); }

            if (Input.GetMouseButtonDown(1) && !IsParryCooldown)
            {
                StartCoroutine(Parry());
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && !IsCooldownS)
            {
                Element.MoveShift(transform, 0);
                StartCoroutine(StartCooldownShift());
            }

            if (Input.GetKeyDown(KeyCode.E))
            { ChangeElement(); UpdateSprite(); }

            if (Input.GetKey(KeyCode.S))
            {
                MainUIManager.Instance.MoveDefaultLayer(gameObject);
            }

            ApplyForce(translateX * 500, 0);
            UpdateAnimationParameters();
            HandleMouseHold();

            MainUIManager.Instance.UpdateStaminaBar(Stamina, MaxStamina);
        }
    }

    public override void Jump()
    {
        IsJumping = true;
    }

#pragma warning disable IDE0051 // Remove unused private members
    private void ApplyJumpForce()
#pragma warning restore IDE0051 // Remove unused private members
    {
        ApplyForce(0, 600);
    }

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

    private IEnumerator InitComboTimer()
    {
        yield return new WaitForSeconds(_comboTimer);
        _comboCount = 0;
    }

    private void HandleIdleAiming()
    {
        if (Input.GetKeyDown(KeyCode.D)) { LastXInput = 1; }
        else if (Input.GetKeyDown(KeyCode.A)) { LastXInput = -1; }

        float angleRad = Mathf.Atan2(LastYInput, LastXInput);
        if (IsLookingRight)
        {
            if (Input.GetKeyDown(KeyCode.W) && angleRad < Math.PI / 2)
            {
                angleRad += (float)Math.PI / 4;
            }
            else if (Input.GetKeyDown(KeyCode.S) && angleRad > -1 * Math.PI / 2)
            {
                angleRad -= (float)Math.PI / 4;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) && angleRad != (float)Math.PI / 2)
            {
                angleRad -= (float)Math.PI / 4;
            }
            else if (Input.GetKeyDown(KeyCode.S) && angleRad != (float)Math.PI / -2)
            {
                angleRad += (float)Math.PI / 4;
            }
        }

        Vector2 x = new Vector2(Mathf.Cos(angleRad), 0);
        Vector2 y = new Vector2(0, Mathf.Sin(angleRad));
        x = x.normalized;
        y = y.normalized;

        LastXInput = (int)x.x;
        LastYInput = (int)y.y;
    }

    private void HandleMouseHold()
    {
        // Mouse Hold down
        if (Input.GetMouseButton(0))
        {
            if (_chargeCoroutine == null)
            {
                _chargeCoroutine = StartCoroutine(ChargedShot());
            }
        }
        //else
        //{
        //    if (IsCharged == false)
        //    {
        //        if (_chargeCoroutine != null)
        //        {
        //            StopCoroutine(_chargeCoroutine);
        //            _chargeCoroutine = null;
        //            RegularShot();
        //        }
        //    }
        //    else
        //    {
        //        StartCoroutine(Element.MoveMouseTwo(transform, 0));
        //        IsCharged = false;
        //        _chargeCoroutine = null;
        //    }
        //}
    }

#pragma warning disable IDE0051 // Remove unused private members
    private void AnimationReleaseShoot()
#pragma warning restore IDE0051 // Remove unused private members

    {
        if (IsCharged == false)
        {
            if (_chargeCoroutine != null)
            {
                StopCoroutine(_chargeCoroutine);
                _chargeCoroutine = null;
                RegularShot();
            }
        }
        else
        {
            StartCoroutine(Element.MoveMouseTwo(transform, 0));
            IsCharged = false;
            _chargeCoroutine = null;
        }
    }

    private void RegularShot()
    {
        if (!IsCooldownA)
        {
            if (_comboCoroutine != null && _comboCount > 0) { StopCoroutine(_comboCoroutine); }
            _comboCoroutine = StartCoroutine(InitComboTimer());

            _comboCount++;
            if (_comboCount < _comboMin) { StartCoroutine(Element.MoveMouseOne(transform, 0)); }
            else { StartCoroutine(Element.MoveMouseTwo(transform, 0)); }

            StartCoroutine(StartCooldownA());
        }
    }

    private IEnumerator ChargedShot()
    {
        yield return new WaitForSeconds(ChargedShotDur);
        IsCharged = true;
    }

}