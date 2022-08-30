using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileVania.Abstracts.Inputs;

namespace TileVania.Inputs
{
    public class PcInputs : IPlayerInput
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");
        public float Vertical => Input.GetAxisRaw("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}


