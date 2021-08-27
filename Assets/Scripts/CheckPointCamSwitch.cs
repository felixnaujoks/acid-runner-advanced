using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCamSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("CameraScript").GetComponent<CameraSwitch>().checkPointSwitchCam = true;
        }
    }
}
