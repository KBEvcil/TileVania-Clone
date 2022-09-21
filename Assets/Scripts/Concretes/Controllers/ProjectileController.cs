using System.Collections;
using System.Collections.Generic;
using TileVania.Combat;
using TileVania.Movement;
using UnityEngine;

namespace TileVania.Controllers
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private string[] _canHitToTags;
        private Damage _damage;
        private Mover _mover;
        private Flip _flip;

        private void Awake()
        {
            _damage = GetComponent<Damage>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(CheckTags(collision))
            {
                Health health = collision.GetComponent<Health>();
                if(health != null)
                {
                    health.TakeHit(_damage);
                }
                Destroy(gameObject);
            }
        }

        private bool CheckTags(Collider2D collision)
        {
            foreach(string tag in _canHitToTags)
            {
                if (collision.CompareTag(tag))
                    return true;
            }
            return false;
        }

        public void SetMotion(float direction)
        {
            _flip.FlipChar(direction);
            _mover.MoveHorizontally(direction);
        }
    }
}

