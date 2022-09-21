using System.Collections;
using System.Collections.Generic;
using TileVania.Abstracts.Inputs;
using TileVania.Animations;
using TileVania.Combat;
using TileVania.Inputs;
using TileVania.Movement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontal;
    float _vertical;
    float _direction;
    bool _isOnGround;
    bool _isClimbing;

    private IPlayerInput _input;

    private OnGround _onGround;
    private Mover _mover;
    private Jump _jump;
    private Climb _climb;
    private Flip _flip;
    private OnLayer _onLayer;
    private CharacterAnimation _characterAnimation;
    private Health _health;
    private Shoot _shoot;
    private Dash _dash;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _input = new PcInputs();
        _onGround = GetComponent<OnGround>();
        _mover = GetComponent<Mover>();
        _jump = GetComponent<Jump>();
        _climb = GetComponent<Climb>();
        _flip = GetComponent<Flip>();
        _onLayer = GetComponent<OnLayer>();
        _characterAnimation = GetComponent<CharacterAnimation>();
        _health = GetComponent<Health>();
        _shoot = GetComponent<Shoot>();
        _dash = GetComponent<Dash>();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameCanvas canvas = FindObjectOfType<GameCanvas>();
        if(canvas != null)
        {
            _health.OnDeath += canvas.ShowGameOverPanel;
            DisplayHealth displayHealth = canvas.GetComponentInChildren<DisplayHealth>();
            _health.OnHealthChanged += displayHealth.UpdateHealthText;
            _health.OnHealthChanged += _health_OnHealthChanged;
            displayHealth.UpdateHealthText(_health.MaxHealth);
        }
    }
    private void Update()
    {
        if (_health.IsDead) return;
        _isOnGround = _onGround.IsOnGround;
        _direction = _flip.Direction;
        _horizontal = _input.Horizontal;
        _vertical = _input.Vertical;
        _isClimbing = _onLayer.IsTouchingLayer("Ladder") && !_isOnGround;

        if (_input.IsJumpButtonDown)
            if (_isOnGround)
            {
                _jump.JumpAction();
                AudioManager.Instance.Play("Jump");
            }
        if (_dash.CanDash && _horizontal != 0 && _input.IsDashButtonDown)
            _dash.DoDash(_direction);

        _flip.FlipChar(_horizontal);
        _characterAnimation.MoveAnimation(_horizontal);
        _characterAnimation.JumpAnimation(!_isOnGround, _rb.velocity.y);
        _characterAnimation.ClimbAnimation(_isClimbing, _vertical);
        _characterAnimation.DashAnimation(_dash.IsDashing);

        if(_input.Shooted && _isOnGround)
        {
            _shoot.ShootProjectile(_direction);
            _characterAnimation.ShootAnimation(true);
        }
    }
    void FixedUpdate()
    {
        if (_health.IsDead || _dash.IsDashing) return;
        _mover.MoveHorizontally(_horizontal);
        _climb.ClimbAction(_vertical);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Hazzard")) return;
        Damage attacker = collision.gameObject.GetComponent<Damage>();
        if (attacker != null)
        {
            attacker.HitTarget(_health);
        }
    }

    private void _health_OnHealthChanged(int num)
    {
        AudioManager.Instance.Play("PlayerDeath");
    }

}
