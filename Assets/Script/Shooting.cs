using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

  public GameObject bulletPrefab;
  public float shotSpeed;
  private float shotInterval;

  void Update()
  {
    shotInterval += 1;
    if (shotInterval > 18 && Input.GetMouseButtonDown(0))
    {
      ArrowShot();
    }
  }

  void ArrowShot()
  {

    GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z - 15));
    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
    bulletRb.AddForce(transform.forward * shotSpeed);

    Destroy(bullet, 3.0f);
    shotInterval = 0;

  }

}