using System.Collections;
using System.Collections.Generic;
using TileVania.Abstracts.Inputs;
using TileVania.Animations;
using TileVania.Inputs;
using TileVania.Movement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontal;
    float _vertical;
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

        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _isOnGround = _onGround.IsOnGround;
        _horizontal = _input.Horizontal;
        _vertical = _input.Vertical;
        _isClimbing = _onLayer.IsTouchingLayer("Ladder") && !_isOnGround;
        if (_input.IsJumpButtonDown)
            if (_isOnGround)
                _jump.JumpAction();
        _flip.FlipChar(_horizontal);
        _characterAnimation.MoveAnimation(_horizontal);
        _characterAnimation.JumpAnimation(!_isOnGround, _rb.velocity.y);
        _characterAnimation.ClimbAnimation(_isClimbing, _vertical);
    }
    void FixedUpdate()
    {
        _mover.MoveHorizontally(_horizontal);
        _climb.ClimbAction(_vertical);
    }

}
