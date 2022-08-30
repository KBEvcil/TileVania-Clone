using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania.Movement
{
    public class Climb : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _bc2d;
        [SerializeField] private Rigidbody2D _rb2d;
        [SerializeField] private float _climbSpeed;

        private float _gravityScale;

        private void Awake()
        {
            _gravityScale = _rb2d.gravityScale;
        }

        public void ClimbAction(float vertical)
        {
            if (_bc2d.IsTouchingLayers(LayerMask.GetMask("Ladder")))
            {
                _rb2d.gravityScale = 0;
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, vertical * _climbSpeed);
            } else
            {
                _rb2d.gravityScale = _gravityScale;
            }

        }
    }
}

