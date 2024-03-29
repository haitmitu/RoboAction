using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip[] bgm;
    public new AudioSource audio;
    public float[] bgmV;
    public float volume;
    public int startBgm;

    // Start is called before the first frame update
    void Awake()
    {
        StartBgm(0, startBgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //BGMX^[g
    public void StartBgm(float time,int number)
    {
        audio.clip = bgm[number];
        audio.volume =  Mathf.Clamp(volume * bgmV[number],0,1);
        audio.time = time;
        audio.Play();
    }
    //êâ~ð
    public void PauseBgm()
    {
        audio.Pause();
    }
    //êâ~
    public void StopBgm()
    {
        audio.Stop();
    }
}
