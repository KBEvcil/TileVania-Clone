using System.Collections;
using System.Collections.Generic;
using TileVania.Animations;
using TileVania.Combat;
using TileVania.Managers;
using TileVania.Movement;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private float _direction;

    private CharacterAnimation _characterAnimation;
    private Health _health;
    private Damage _damage;
    private Mover _mover;
    private Flip _flip;

    private void Awake()
    {
        _characterAnimation = GetComponent<CharacterAnimation>();
        _health = GetComponent<Health>();
        _damage = GetComponent<Damage>();
        _mover = GetComponent<Mover>();
        _flip = GetComponent<Flip>();
        _direction = 1f;
    }

    private void Start()
    {
        _health.OnDeath += _health_OnDeath;
    }

    private void Update()
    {
        if (_health.IsDead) return;
        _mover.MoveHorizontally(_direction);
    }


    private void _health_OnDeath()
    {
        GameManager.Instance.UpdateScore(5);
        AudioManager.Instance.Play("EnemyDeath");
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if(playerHealth != null)
            {
                playerHealth.TakeHit(_damage);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyArea"))
        {
            _direction *= -1;
            _flip.FlipChar(_direction);
        }
    }
}
