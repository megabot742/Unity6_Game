using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
   [SerializeField] Animator animator;
   [SerializeField] float collisionCoolDown = 1f;
   [SerializeField] float nagativeMoveSpeed = -4f;
   
   const string hitString = "Hit";
   float cooldownTimer = 0f;

   LevellGenerator levellGenerator;
   void Start()
   {
      levellGenerator= FindFirstObjectByType<LevellGenerator>();
   }
   void Update()
   {
      cooldownTimer += Time.deltaTime;
   }
   void OnCollisionEnter(Collision other)
   {
      if(cooldownTimer < collisionCoolDown) return;
      levellGenerator.ChangeChunkMoveSpeed(nagativeMoveSpeed);
      animator.SetTrigger(hitString);
      cooldownTimer = 0f;
   }
   
}
