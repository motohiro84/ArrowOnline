using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArrow : MonoBehaviour
{
  private FixedJoint fixedJoint;

  public GameObject ArrowIn;
  public static GameObject partName;
  PlayerHp playerHp;

  void Start()
  {
    playerHp = GameObject.Find("Player").GetComponent<PlayerHp>();
  }

  void OnCollisionEnter(Collision col)
  {

    Destroy(gameObject);
    GameObject bullet = (GameObject)Instantiate(ArrowIn, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z));

    if (col.gameObject.tag == "Player")
    {
      partName = col.gameObject;
      playerHp.Damage();

      if (fixedJoint == null)
      {
        bullet.gameObject.AddComponent<FixedJoint>();
        fixedJoint = bullet.GetComponent<FixedJoint>();
        fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody>();
        fixedJoint.breakForce = Mathf.Infinity;
        fixedJoint.breakTorque = Mathf.Infinity;
        fixedJoint.enableCollision = false;
        fixedJoint.enablePreprocessing = false;

        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.GetComponent<Rigidbody>().Sleep();
      }

    }

    Destroy(bullet, 15.0f);
  }

}