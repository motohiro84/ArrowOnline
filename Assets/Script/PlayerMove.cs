using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class PlayerMove : StrixBehaviour
{
  public GameObject Player;
  public float speed;
  public float dashForce;
  private Transform playerTransform;
  private Rigidbody rb;
  public float MoveKey;
  public static bool stratMoveKey;
  Motion motion;
  public float dashCT;
  private bool dashKey;
  private bool obstacleKey = true;



  void Start()
  {
    dashKey = true;
    rb = Player.GetComponent<Rigidbody>();
    playerTransform = Player.transform;
    motion = GetComponent<Motion>();
    MoveKey = -1f;
    motion.MoveMotion(MoveKey);
    stratMoveKey = false;
  }


  void Update()
  {
    Move();
    obstacleKey = true;
  }


  void Move()
  {
    if (isLocal == false)
    {
      return;
    }
    if (stratMoveKey)
    {
      float x = Input.GetAxisRaw("Horizontal");
      float z = Input.GetAxisRaw("Vertical");
      Vector3 dir = (transform.right * x) + (transform.forward * z);

      if (!Shooting.ImmovableKey)
      {
        return;
      }
      else if (Input.GetKeyDown(KeyCode.Space) && dashKey)
      {
        dashKey = false;
        if (x == 0 || z == 0)
        {
          rb.AddForce(dir * dashForce * 1.5f, ForceMode.Impulse);
        }
        else
        {
          rb.AddForce(dir * dashForce, ForceMode.Impulse);
        }
        motion.DashMotion();
        Invoke("DashCT", dashCT);
        return;
      }

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
      {
        MoveKeyCheck();
        motion.MoveMotion(MoveKey);
        if (!obstacleKey)
        {
          Player.transform.position += (dir * speed * Time.deltaTime) * -1.5f;
          return;
        }
        Player.transform.position += dir * speed * Time.deltaTime;
      }
      else
      {
        MoveKey = -1f;
        motion.MoveMotion(MoveKey);
      }
    }
  }

  void MoveKeyCheck()
  {
    if (Input.GetKey(KeyCode.W))
    {
      MoveKey = 0f;
    }
    else if (Input.GetKey(KeyCode.S))
    {
      MoveKey = 1f;
    }
    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    {
      MoveKey = 0.5f;
    }
  }

  void DashCT()
  {
    dashKey = true;
  }

  Vector3 hitPos;
  void OnCollisionStay(Collision col)
  {
    foreach (ContactPoint point in col.contacts)
    {
      hitPos = point.point;
    }

    if (LayerMask.LayerToName(col.gameObject.layer) == "Obstacle")
    {
      obstacleKey = false;
      Vector3 toVec = GetAngleVec();

      rb.AddForce(toVec * 10, ForceMode.Impulse);
    }
    else if (LayerMask.LayerToName(col.gameObject.layer) == "Pillar")
    {
      obstacleKey = false;
      Vector3 toVec = GetAngleVec();

      rb.AddForce(toVec * 5, ForceMode.Impulse);
    }

  }

  Vector3 GetAngleVec()
  {
    Vector3 fromVec = new Vector3(hitPos.x, 0, hitPos.z);
    Vector3 toVec = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
    return Vector3.Normalize(toVec - fromVec);
  }

}
