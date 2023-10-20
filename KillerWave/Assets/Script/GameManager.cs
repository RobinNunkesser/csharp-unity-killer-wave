using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        CheckGameManagerIsInTheScene();
    }

    private void CheckGameManagerIsInTheScene()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraSetup();
        LightSetup();
    }

    void CameraSetup()
    {
        var gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameCamera.transform.position = new Vector3(0, 0, -300);
        gameCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        var camera = gameCamera.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color32(0, 0, 0, 255);
    }

    void LightSetup()
    {
        var dirLight = GameObject.Find("Directional Light");
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Light>().color = new Color32(152, 204, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
