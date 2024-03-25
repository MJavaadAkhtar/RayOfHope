using UnityEngine;


namespace RayOfHope
{
    public class Lumi_States : MonoBehaviour
    {
        Animator anim;
        void Awake()
        {
            anim = GetComponent<Animator>();
        }
        void ResetAnimation()
        {
            anim.SetBool("isLookUp", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
        }
        public void Idle()
        {
            ResetAnimation();
            anim.SetTrigger("idle");
        }
        public void LookUp()
        {
            ResetAnimation();
            anim.SetBool("isLookUp", true);
        }
        public void Run()
        {
            ResetAnimation();
            anim.SetBool("isRun", true);
        }
        public void Jump()
        {
            ResetAnimation();
            anim.SetBool("isJump", true);
        }
    }
}
