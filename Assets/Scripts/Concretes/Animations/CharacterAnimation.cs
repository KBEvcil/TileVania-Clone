using System.Collections;
using System.Collections.Generic;
using TileVania.Movement;
using UnityEngine;

namespace TileVania.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        
        public void MoveAnimation(float horizontal)
        {
            _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        }

        public void JumpAnimation(bool isJumping, float velocityY)
        {
            _animator.SetBool("IsJumping", isJumping);
            _animator.SetFloat("VelocityY", velocityY);
        }

        public void ClimbAnimation(bool isClimbing, float vertical)
        {
            _animator.SetBool("IsClimbing", isClimbing);
            _animator.SetFloat("Vertical", vertical);
        }

        public void ShootAnimation(bool isShooting)
        {
            _animator.SetBool("IsShooting", isShooting);
            if (isShooting)
                StartCoroutine(ShootAnimationExit());
        }

        public void DashAnimation(bool isDashing)
        {
            _animator.SetBool("IsDashing", isDashing);
        }

        private IEnumerator ShootAnimationExit()
        {
            yield return new WaitForSeconds(Time.deltaTime);
            ShootAnimation(false);
        }
    }
}

