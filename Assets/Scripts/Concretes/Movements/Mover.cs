using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TileVania.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _moveSpeed = 5f;

        
        public void MoveHorizontally(float horizontalInput)
        {
            _rb.velocity = new Vector2(horizontalInput * _moveSpeed, _rb.velocity.y);
        }
    }
}

