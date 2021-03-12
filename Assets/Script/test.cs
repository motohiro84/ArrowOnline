using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
  void OnCollisionEnter(Collision col)
  {
    Debug.Log(col.gameObject.name);

  }
}
