using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TekiMove : MonoBehaviour
{
    public Transform teki, pl;
    bool mo;
    public Vector3 startP;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (startP==Vector3.zero)
        {
            startP = teki.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mo)
        {
            Move();
        }
        else
        {
            if (Vector3.Distance(teki.position,startP)<=10)
            {
                Look();
            }
            else
            {
                Walk();
            }
        }
    }
    public void Look()
    {
        animator.SetTrigger("look");
        if (Vector3.Distance(teki.position, pl.position)<=30)
        {
            teki.rotation = Quaternion.LookRotation(new Vector3(pl.position.x, 0, pl.position.z) - new Vector3(teki.position.x, 0, teki.position.z));
            mo = true;
        }
        else
        {
        }

    }
    public void Move()
    {
        if (Vector3.Distance(teki.position, pl.position) >= 4)
        {
            animator.SetTrigger("walk");
            teki.rotation = Quaternion.LookRotation(new Vector3(pl.position.x,0,pl.position.z) - new Vector3(teki.position.x, 0, teki.position.z));
            teki.position += teki.forward * Time.deltaTime*8;
        }
        else
        {
            animator.SetTrigger("idle");

            
        }
        if (Vector3.Distance(teki.position, pl.position) >= 40)
        {
            mo = false;
        }
    }
    public void Walk()
    {
        animator.SetTrigger("walk");
        teki.rotation = Quaternion.LookRotation(new Vector3(startP.x, 0, startP.z) - new Vector3(teki.position.x, 0, teki.position.z));
        teki.position += teki.forward * Time.deltaTime * 8;
    }
}
