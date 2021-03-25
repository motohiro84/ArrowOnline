using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
  public void OnClick()
  {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    PlayerMove.stratMoveKey = true;
    PlayerCamera.cameraKey = true;
  }


}
