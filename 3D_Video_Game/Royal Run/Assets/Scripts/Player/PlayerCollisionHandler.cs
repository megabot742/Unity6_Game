using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
   [SerializeField] Animator animator;
   [SerializeField] float collisionCoolDown = 1f;
   const string hitString = "Hit";
   float cooldownTimer = 0f;
   void Update()
   {
      cooldownTimer += Time.deltaTime;
   }
   void OnCollisionEnter(Collision other)
   {
      if(cooldownTimer < collisionCoolDown) return;

      animator.SetTrigger(hitString);
      cooldownTimer = 0f;
   }
   
}
