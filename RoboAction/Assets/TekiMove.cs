using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TekiMove : MonoBehaviour
{
    public Transform teki, pl;
    bool mo;
    public Vector3 startP;
    float startA=10;
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
            if (teki.position.x <= startA + startP.x&& teki.position.x >=startP.x- startA && teki.position.z <= startA + startP.z && teki.position.z >= startP.z - startA)
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
            teki.rotation = Quaternion.LookRotation(new Vector3(pl.position.x,0,pl.position.z) - new Vector3(teki.position.x, 0, teki.position.z));
            teki.position += teki.forward * Time.deltaTime*8;
        }
        if (Vector3.Distance(teki.position, pl.position) >= 40)
        {
            mo = false;
        }
    }
    public void Walk()
    {
        teki.rotation = Quaternion.LookRotation(new Vector3(startP.x, 0, startP.z) - new Vector3(teki.position.x, 0, teki.position.z));
        teki.position += teki.forward * Time.deltaTime * 8;
    }
}
