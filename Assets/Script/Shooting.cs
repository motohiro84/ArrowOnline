using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

  public GameObject bulletPrefab;
  public float shotSpeed;
  public static bool IntervalKey = true;
  public static bool ImmovableKey = true;

  void Update()
  {
    if (IntervalKey && Input.GetMouseButtonDown(0))
    {
      IntervalKey = false;
      ImmovableKey = false;
      StartCoroutine("FireShot");
    }
  }


  private IEnumerator FireShot()
  {
    for (int i = 1; i < 4; i++)
    {
      yield return new WaitForSeconds(0.25f);

      if (i == 2)
      {

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z - 15));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * shotSpeed);

        yield return new WaitForSeconds(0.15f);
      }
      if (i == 3)
      {
        IntervalKey = true;
        ImmovableKey = true;
        yield break;
      }
    }
  }

}