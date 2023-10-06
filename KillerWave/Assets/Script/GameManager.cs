using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraSetup();    
    }

    void CameraSetup() {
        var gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameCamera.transform.position = new Vector3(0,0,-300);
        gameCamera.transform.eulerAngles = new Vector3(0,0,0);

        var camera = gameCamera.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color32(0,0,0,255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
