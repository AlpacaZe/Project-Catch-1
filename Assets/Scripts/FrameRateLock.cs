using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
