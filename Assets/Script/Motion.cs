using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class Motion : StrixBehaviour
{
  public GameObject WoodenBow;

  private Animator BowAnimator;
  private Animator animator;
  AnimatorStateInfo animatorStateInfo;

  void Start()
  {
    animator = this.gameObject.GetComponent<Animator>();
    BowAnimator = WoodenBow.GetComponent<Animator>();
  }

  void Update()
  {
    animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

    if (GetInput() && Shooting.IntervalKey)
    {
      Shot();
    }

  }

  bool GetInput()
  {
    return Input.GetMouseButtonDown(0);
  }

  void Shot()
  {
    if (!isLocal || !PlayerMove.stratMoveKey)
    {
      return;
    }

    animator.SetTrigger("Shot");
    BowAnimator.SetTrigger("Shot");
  }

  public void MoveMotion(float speed)
  {
    animator.SetFloat("Move", speed);
  }
  public void DashMotion()
  {
    animator.SetTrigger("Dash");
  }

}
