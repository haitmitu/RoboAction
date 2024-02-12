using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movie_Camera : MonoBehaviour
{
    public GameObject camera;
    public float time, po;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }
    }
    public void Move()
    {
        camera.transform.DOMoveY(po,time);
    }
}
