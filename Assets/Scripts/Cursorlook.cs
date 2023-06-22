using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorlook : MonoBehaviour
{
  public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
