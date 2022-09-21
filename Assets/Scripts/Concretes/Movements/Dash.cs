using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float _dashForce;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _dashCooldown;
    public bool IsDashing;
    public bool CanDash;

    private float _oldGravityScale;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CanDash = true;
    }
    public void DoDash(float direction)
    {
        IsDashing = true;
        CanDash = false;
        _oldGravityScale = _rb2d.gravityScale;
        _rb2d.gravityScale = 0;
        _rb2d.velocity = Vector2.zero;
        _rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rb2d.AddForce(_dashForce * Vector2.right * direction, ForceMode2D.Impulse);
        StartCoroutine(EndDash());
        StartCoroutine(ReloadDash());
    }

    private IEnumerator EndDash()
    {
        yield return new WaitForSeconds(_dashDuration);
        IsDashing = false;
        _rb2d.gravityScale = _oldGravityScale;
        _rb2d.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
    }

    private IEnumerator ReloadDash()
    {
        yield return new WaitForSeconds(_dashCooldown);
        CanDash = true;
    }



}
