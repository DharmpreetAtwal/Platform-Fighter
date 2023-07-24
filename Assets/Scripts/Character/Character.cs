using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private SpriteRenderer SpriteRen { get; set; }

    public bool IsLookingRight { get; protected set; }
    public bool IsLookingUp { get; protected set; }
    public bool IsJumping { get; set; }
    public bool IsCooldownA { get; protected set; }
    public bool IsCooldownB { get; protected set; }
    public bool IsCooldownS { get; protected set; }
    public bool IsMovementEnabled { get; set; }
    public bool IsParryCooldown { get; protected set; }
    public bool IsParrying { get; protected set; }
    public bool IsCharged { get; protected set; }
    public bool NoneXInput { get; protected set; }
    public bool NoneYInput { get; protected set; }

    private Element _element;
    public Element Element {
        get { return _element; }
        set { _element = value; }
    }
    private float _maxHealth;
    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    private float _health;
    public float Health
    {
        get { return _health; }
        set
        {
            if (value > 0 && value <= _maxHealth) { _health = value; }
            else if (value > 0 && value > _maxHealth) { _health = _maxHealth; }
            else { _health = 0; }
        }
    }
    private float _maxStamina;
    public float MaxStamina
    {
        get { return _maxStamina; }
        private set { _maxStamina = value; }
    }
    private float _stamina;
    public float Stamina
    {
        get { return _stamina; }
        set {
            if (value <= _maxStamina)
            {
                _stamina = value;
            }
            else
            {
                _stamina = _maxStamina;
            }
        }
    }
    private float _maxSpeedX;
    public float MaxSpeedX
    {
        get { return _maxSpeedX; }
        private set { _maxSpeedX = value; }
    }

    private float _parryCoolDur;
    public float ParryCoolDur
    {
        get { return _parryCoolDur; }
        private set { _parryCoolDur = value; }
    }
    private float _parryDur;
    public float ParryDur
    {
        get { return _parryDur; }
        private set { _parryDur = value; }
    }
    private float _chargedShotDur;
    public float ChargedShotDur
    {
        get { return _chargedShotDur; }
        private set { _chargedShotDur = value; }
    }

    private int _lastXInput;
    public int LastXInput
    {
        get { return _lastXInput; }
        protected set { _lastXInput = value; }
    }
    private int _lastYInput;
    public int LastYInput
    {
        get { return _lastYInput; }
        protected set { _lastYInput = value; }
    }

    private void Awake()
    {
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
        IsLookingRight = true;
        IsLookingUp = false;
        NoneXInput = true;
        NoneYInput = true;
        IsJumping = false;
        IsCooldownA = false;
        IsCooldownB = false;
        IsMovementEnabled = true;
        IsParryCooldown = false;
        IsParrying = false;
        IsCharged = false;

        _parryCoolDur = 1.0f;
        _parryDur = 0.5f;
        _chargedShotDur = 2.0f;
        _lastXInput = 1;
        _lastYInput = 0;

        UpdateSprite();
        InvokeRepeating(nameof(RecoverStamina), 0.0f, 0.1f);
    }

    public void Init(Element elem, float maxHealth, float health,
        float maxStam, float stamina)
    {
        _element = elem;
        _maxHealth = maxHealth;
        _health = health;
        _maxStamina = maxStam;
        _stamina = stamina;
        _maxSpeedX = 10;

        Awake();
    }

    protected void UpdateSprite()
    {
        if (_element.GetType() == typeof(Air))
        { SpriteRen.color = Color.white; }
        else if (_element.GetType() == typeof(Earth))
        { SpriteRen.color = Color.green; }
        else if (_element.GetType() == typeof(Fire))
        { SpriteRen.color = Color.red; }
        else if (_element.GetType() == typeof(Water))
        { SpriteRen.color = Color.blue; }
    }

    public void ApplyForce(float x, float y)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(x, y), ForceMode2D.Force);
    }

    public void ApplyImpulse(float x, float y)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(
            new Vector3(x, y), ForceMode2D.Impulse);
    }

    public virtual void TakeDamage(float dmg)
    {
        _health -= (dmg / _element.Defence);
        if(_health <= 0) { Destroy(gameObject); }
    }

    public void RecoverStamina()
    {
        if(_stamina < _maxStamina)
        {
            _stamina += 1 * _element.Endurance;
        }
    }

    protected IEnumerator StartCooldownA()
    {
        IsCooldownA = true;
        yield return new WaitForSeconds(Element.CooldownADuration);
        IsCooldownA = false;
    }

    protected IEnumerator StartCooldownB()
    {
        IsCooldownB = true;
        yield return new WaitForSeconds(Element.CooldownBDuration);
        IsCooldownB = false;
    }

    protected IEnumerator StartCooldownShift()
    {
        IsCooldownS = true;
        yield return new WaitForSeconds(Element.CooldownSDuration);
        IsCooldownS = false;
    }

    protected IEnumerator StartCooldownParry()
    {
        IsParryCooldown = true;
        yield return new WaitForSeconds(_parryCoolDur);
        IsParryCooldown = false;
    }

    public int GetDirectionX()
    {
        if (NoneXInput) { return 0; }
        else if (IsLookingRight) { return 1;}
        else {  return -1; }
    }

    public int GetDirectionY()
    {
        if (NoneYInput) { return 0; }
        else if (IsLookingUp) { return 1; }
        else { return -1; }
    }

    public abstract void Jump();

    public IEnumerator Parry()
    {
        IsParrying = true;
        yield return new WaitForSeconds(_parryDur);
        IsParrying = false;
        StartCoroutine(StartCooldownParry());
    }

    protected void CheckMaxVelocityX()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (Mathf.Abs(rb.velocity.x) > _maxSpeedX)
        {
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(-_maxSpeedX, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(_maxSpeedX, rb.velocity.y);
            }
        }
    }
}
