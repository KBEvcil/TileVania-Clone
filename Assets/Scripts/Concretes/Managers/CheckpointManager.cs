using System;
using System.Collections;
using System.Collections.Generic;
using TileVania.Combat;
using TileVania.Controllers;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private CheckpointController _activeCheckpoint;
    private Health _health;

    public static CheckpointManager Instance { get; private set; }
    public event Action<CheckpointController> OnCheckpointChanged;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        } 
        else
        {
            Instance = this;
        }
        _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        _health.OnHealthChanged += _health_OnHealthChanged;
    }

    private void _health_OnHealthChanged(int health)
    {
        if (_activeCheckpoint == null || health < 1) return;
        _health.transform.position = _activeCheckpoint.transform.position;
    }

    public void SetActiveCheckpoint(CheckpointController checkpoint)
    {
        _activeCheckpoint = checkpoint;
        OnCheckpointChanged?.Invoke(checkpoint);
    }

    
}
