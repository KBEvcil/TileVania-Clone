using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania.Controllers
{
    public class CheckpointController : MonoBehaviour
    {
        [SerializeField] private Sprite _activeSprite;
        [SerializeField] private Sprite _inactiveSprite;

        private SpriteRenderer _sr;
        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }
        private void OnEnable()
        {
            CheckpointManager.Instance.OnCheckpointChanged += CheckpointManager_OnCheckpointChanged;
        }

        private void OnDisable()
        {
            CheckpointManager.Instance.OnCheckpointChanged -= CheckpointManager_OnCheckpointChanged;
        }

        private void CheckpointManager_OnCheckpointChanged(CheckpointController checkpoint)
        {
            if (_sr == null) return;
            _sr.sprite = checkpoint == this ? _activeSprite : _inactiveSprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                CheckpointManager.Instance.SetActiveCheckpoint(this);
            }
        }
    }
}

