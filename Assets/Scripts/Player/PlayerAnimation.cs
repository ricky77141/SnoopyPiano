using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void PlayWalk(int walk)
        {
            anim.SetInteger(Tags.WALK_ANIM_PARAM, walk);
        }

        public void PlayJump(bool grounded, float ySpeed)
        {
            anim.SetBool(Tags.JUMP_ANIM_PARAM, grounded);
            anim.SetFloat(Tags.yVelocity, ySpeed);
        }

        public void PlayHammer()
        {
            anim.SetTrigger(Tags.HAMMER_HIT);
        }
        
        public void PlayHammerWalk()
        {
            anim.SetTrigger(Tags.HAMMER_HIT_WALK);
        }

        public void PlayAnimWithName(string animName)
        {
            anim.Play(animName);
        }
        
    }
}
