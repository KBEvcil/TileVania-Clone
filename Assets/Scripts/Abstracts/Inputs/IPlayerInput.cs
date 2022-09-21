using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsJumpButtonDown { get; }
        bool Shooted { get; }
        bool IsDashButtonDown { get; }
    }
}

