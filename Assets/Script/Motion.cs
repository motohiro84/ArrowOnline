using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
  private Animator animator;
  private string state;
  AnimatorStateInfo animatorStateInfo;
  void Start()
  {
    animator = this.gameObject.GetComponent<Animator>();
  }


  void Update()
  {
    animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

    if (GetInput())
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
    animator.SetTrigger("Shot");
  }


}
