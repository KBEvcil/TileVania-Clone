using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

public class CoinController : Collectable
{
    [SerializeField] private int _score;
    private CoinAnimation _coinAnimation;
    private bool _isCollected;

    private void Awake()
    {
        _coinAnimation = GetComponent<CoinAnimation>();
    }

    private void Start()
    {
        _isCollected = false;
    }

    protected override void OnCollected()
    {
        if (_isCollected) return;
        _isCollected = true;
        GameManager.Instance.UpdateScore(_score);
        _coinAnimation.CollectAnimation();
        AudioManager.Instance.Play("Coin");
        delay = _coinAnimation.Animator.GetCurrentAnimatorStateInfo(0).length;
        base.OnCollected();
    }
}
