using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//これはテスト用です
public class PlayerMove : MonoBehaviour
{
    float ws;
    float ad;
    public string[] text;
    public UIMaster ui;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //キー入力
        //WASD();
    }
    void WASD()
    {
        ws = Input.GetAxis("Vertical");
        ad = Input.GetAxis("Horizontal");
        transform.position += new Vector3(ad, 0, ws) * 0.4f;
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name=="item")
        {
            if (Input.GetKeyDown("e"))
            {
                ui.textBox.A(text,name);
            }
        }

    }
}
