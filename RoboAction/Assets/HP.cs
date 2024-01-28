using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp=10;
    public UIMaster ui;
    // Start is called before the first frame update
    void Awake()
    {
        ui.hp.maxHp = hp;
        ui.hp.hp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "attack")
        {
            hp -= 1;
            ui.hp.hp = hp;
        }
    }
}
