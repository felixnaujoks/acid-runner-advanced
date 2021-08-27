using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraSwitch : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject sideCamera;

    AudioListener mainCameraAudio;
    AudioListener sideCameraAudio;

    public bool sideCamEnding = false;
    public bool checkPointSwitchCam = false;
    
    
    void Start()
    {

        //There appears a problem when there are multiple cameras and there audiolisteners are
        //on, as Unity just wants to have one activ Audiolistener. Therefore to later deactivate
        //them, we pull them here first
        mainCameraAudio = mainCamera.GetComponent<AudioListener>();
        sideCameraAudio = sideCamera.GetComponent<AudioListener>();

        //set the first camera position remembered from the last round
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }
    
    void Update()
    {
        //call the function that checks input for camera change
        inputToSwitch();
    }

    //three inputs to switch the camera. Press C, pass through a (invisible) checkpoint or die
    void inputToSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C) || sideCamEnding || checkPointSwitchCam)
        {
            cameraValueAdding();
            checkPointSwitchCam = false;
        }

        
    }

    //cameras have values 0 and 1. if the input asks for it, we add 1 to the counter. later we
    //see that if the value is 2, its equal to zero again.
    void cameraValueAdding()
    {
        //making sure the game ends with the side view
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        if (sideCamEnding && cameraPositionCounter == 0)
        {
            cameraPositionCounter++;
            cameraPositionChange(cameraPositionCounter);
            
        }
        //besides that, just call to switch the camera
        if (sideCamEnding == false)
        {
            cameraPositionCounter++;
            cameraPositionChange(cameraPositionCounter);
        }
        
        
    }

    //depending on the value, switch to main or side camera
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //remember the camera position
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set main camera
        if (camPosition == 0)
        {
            mainCamera.SetActive(true);
            mainCameraAudio.enabled = true;

            sideCameraAudio.enabled = false;
            sideCamera.SetActive(false);
        }

        //Set side camera
        if (camPosition == 1)
        {
            sideCamera.SetActive(true);
            sideCameraAudio.enabled = true;

            mainCameraAudio.enabled = false;
            mainCamera.SetActive(false);
        }

    }
}