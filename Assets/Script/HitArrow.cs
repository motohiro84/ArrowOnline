using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArrow : MonoBehaviour
{
  public GameObject ArrowIn;

  void OnCollisionEnter(Collision col)
  {

    Destroy(gameObject);
    GameObject bullet = (GameObject)Instantiate(ArrowIn, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z));

  }

}
