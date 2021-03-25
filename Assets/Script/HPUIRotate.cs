using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class HPUIRotate : StrixBehaviour
{
  void Start()
  {
    if (isLocal == true)
    {
      this.gameObject.SetActive(false);
    }
  }

  void LateUpdate()
  {
    transform.rotation = Camera.main.transform.rotation;
  }
}