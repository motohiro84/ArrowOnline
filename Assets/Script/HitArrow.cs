using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class HitArrow : StrixBehaviour
{
  private FixedJoint fixedJoint;

  public GameObject ArrowIn;
  public static GameObject partName;
  PlayerHp playerHp;

  void Start()
  {
  }


  [StrixRpc]
  void OnCollisionEnter(Collision col)
  {

    Destroy(gameObject);
    GameObject bullet = (GameObject)Instantiate(ArrowIn, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z));

    if (col.gameObject.tag == "Player")
    {
      playerHp = col.transform.root.gameObject.GetComponent<PlayerHp>();
      partName = col.gameObject;
      playerHp.RpcToRoomOwner("Damage");

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