using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIn : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    if (GetComponent<FixedJoint>() == null)
    {
      Destroy(gameObject);
    }

  }
}