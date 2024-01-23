using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class walk : MonoBehaviour
{
    public CinemachineDollyCart cart;
    float distance;
    public GameObject player;
    public Text txt;
    float speed;
    bool wait;
    public Animator anim;
    public Transform sendouobj;
    public static int iswalk = 1;
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (wait == false)
        {
            speed = 0.04f;
            iswalk = 1;
            anim.SetBool("nearhito", false);
            transform.LookAt(sendouobj);
            distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
            if (distance < 2.5)
            {
                transform.LookAt(player.transform);
                anim.SetBool("nearhito", true);
                speed = 0;
                iswalk = 0;
                txt.text = "E: 話す";
                if (Input.GetKey(KeyCode.E) == true)
                {
                    Debug.Log("talking");
                    StartCoroutine("talk");
                }
            }
            cart.m_Position += speed;
        }
    }
    IEnumerator talk()
    {
        wait = true;
        anim.SetTrigger("talk");
        yield return new WaitForSeconds(3);
        anim.SetTrigger("talkend");
        wait = false;
    }
}