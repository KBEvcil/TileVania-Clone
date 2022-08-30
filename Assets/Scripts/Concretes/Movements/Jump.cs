using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania.Movement
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float _jumpSpeed = 20f;
        [SerializeField] private Rigidbody2D _rb;

        public void JumpAction()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpSpeed);
        }
    }
}

