using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap :MonoBehaviour
{
    public Material ma;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position+ Vector3.up*5, Vector3.up, out hit,100f))
        {
            ma.color = new Color(0.1f,0.8f,0.1f,0);
            //Debug.Log(hit.transform.name);
        }
        else
        {
            ma.color = Color.green;
        }
    }

    public void Active(bool ac)
    {

    }
}
