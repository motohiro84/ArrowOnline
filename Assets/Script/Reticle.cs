using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
  public GameObject reticle;
  public Sprite normal;
  public Sprite lockOn;
  public GameObject ArrowBox;

  void Update()
  {
    Ray ray = new Ray(ArrowBox.transform.position, ArrowBox.transform.forward);

    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {

      if (hit.collider.tag == "Player")
      {
        reticle.GetComponent<Image>().sprite = lockOn;
        reticle.GetComponent<Image>().color = Color.red;
      }
      else
      {
        reticle.GetComponent<Image>().sprite = normal;
        reticle.GetComponent<Image>().color = Color.green;
      }
    }

  }
}
