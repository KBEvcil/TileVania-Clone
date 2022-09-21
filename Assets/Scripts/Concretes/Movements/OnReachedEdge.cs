using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TileVania.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public class OnReachedEdge : MonoBehaviour
    {
        [SerializeField] private float extraDistance = .1f;
        [SerializeField] private LayerMask layerMask;
        private Collider2D _c2d;
        private float _directionX;
        private void Start()
        {
            _c2d = GetComponent<Collider2D>();
            _directionX = 1f;
        }
        public bool ReachedEdge()
        {
            Vector2 edgeFinderOrigin = new Vector2(GetForwardPositionX(), _c2d.bounds.min.y);
            RaycastHit2D hit = Physics2D.Raycast(edgeFinderOrigin, Vector2.down, extraDistance, layerMask);
            SwitchDirection();
            return hit.collider == null;
        }

        private float GetForwardPositionX()
        {
            return _directionX > 0 ? _c2d.bounds.max.x + extraDistance : _c2d.bounds.min.x - extraDistance;
        }

        private void SwitchDirection()
        {
            _directionX *= -1;
        }
    }
}

