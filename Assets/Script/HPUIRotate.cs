using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class HPUIRotate : StrixBehaviour
{
  void LateUpdate()
  {
    transform.rotation = Camera.main.transform.rotation;
  }
}