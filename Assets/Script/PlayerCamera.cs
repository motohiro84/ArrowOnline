using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class PlayerCamera : StrixBehaviour
{
  public GameObject Player;
  public GameObject Camera;
  private Transform CameraTransform;
  private float ii;
  public static bool cameraKey;

  void Start()
  {
    CameraTransform = Camera.GetComponent<Transform>();
    CameraTransform.Rotate(360f, 0, 0);
    // Cursor.visible = false;
    // Cursor.lockState = CursorLockMode.Locked;
    cameraKey = false;
    if (isLocal == false)
    {
      Camera.SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {
    TPS();
  }

  void TPS()
  {
    if (cameraKey)
    {
      float X_Rotation = Input.GetAxis("Mouse X");
      float Y_Rotation = Input.GetAxis("Mouse Y");
      Player.transform.Rotate(0, X_Rotation, 0);

      ii = (Camera.transform.localEulerAngles.x - Y_Rotation) * Mathf.Deg2Rad;
      ii = Mathf.Sin(ii);

      if (ii > -0.6f && ii < 0.2f)
      {
        Camera.transform.Rotate(-Y_Rotation, 0, 0);
      }
    }

  }
}
