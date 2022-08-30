using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _bc2d;
    [SerializeField] private float _extraDistance = .1f;
    public bool IsOnGround => GroundCheck();

    private bool GroundCheck()
    {
        return Physics2D.BoxCast(_bc2d.bounds.center, _bc2d.bounds.size, 0, Vector2.down, _extraDistance, LayerMask.GetMask("Ground"));
    }

}
