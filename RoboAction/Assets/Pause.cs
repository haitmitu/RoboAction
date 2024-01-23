using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Pause : MonoBehaviour
{
    public GameObject moto;
    public bool pa;
    public CameraScript camera;
    float t=1;
    // Start is called before the first frame update
    public void Starts()
    {
        Pause_Off();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Pause_On()
    {
        camera.cursorLock = false;
        t = Time.timeScale;
        Time.timeScale = 0;
        pa = true;
        moto.SetActive(true);
    }
    public void Pause_Off()
    {
        camera.cursorLock = true;
        Time.timeScale = t;
        pa = false;
        moto.SetActive(false);
        camera.cursorLock = true;
    }
    public void End()
    {
        SceneChange.scene.sc = 0;
    }
    public void StuffedRoll()
    {
        SceneChange.scene.sc = 3;
    }
}
