using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public GameObject Player;
  public float speed;
  private Transform playerTransform;
  private Rigidbody rb;
  public float MoveKey;
  Motion motion;



  void Start()
  {
    // rb = Player.GetComponent<Rigidbody>();
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

    if (!Shooting.ImmovableKey)
    {
      return;
    }
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
    {
      MoveKeyCheck();
      motion.MoveMotion(MoveKey);
      Vector3 dir = (transform.right * x) + (transform.forward * z);
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



}
