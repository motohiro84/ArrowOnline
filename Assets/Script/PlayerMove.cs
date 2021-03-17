using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public GameObject Player;
  public float speed;
  public float dashForce;
  private Transform playerTransform;
  private Rigidbody rb;
  public float MoveKey;
  Motion motion;
  public float dashCT;
  private bool dashKey;



  void Start()
  {
    dashKey = true;
    rb = Player.GetComponent<Rigidbody>();
    playerTransform = Player.transform;
    motion = GetComponent<Motion>();
  }


  void Update()
  {
    Move();
  }


  void Move()
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
      Player.transform.position += dir * speed * Time.deltaTime;
    }
    else
    {
      MoveKey = -1f;
      motion.MoveMotion(MoveKey);
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

}
