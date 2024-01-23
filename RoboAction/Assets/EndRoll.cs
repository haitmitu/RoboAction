using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoll : MonoBehaviour
{
    public int speed= 1;
    int t = 2900;
    public GameObject roll,exit;
    bool stop;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEndRoll());
        stop = false;
        exit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            if (Input.anyKeyDown)
            {
                SceneChange.scene.sc=0;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = 5;
            }
            else
            {
                speed = 2;
            }
        }
        else
        {
            speed = 1;
        }
    }
    IEnumerator StartEndRoll()
    {
        for (int i=1;i<= t;i+=speed)
        {
            roll.transform.localPosition = new Vector3(0,i,0);
            yield return null;
        }
        stop = true;
        exit.SetActive(true);

    }
}
