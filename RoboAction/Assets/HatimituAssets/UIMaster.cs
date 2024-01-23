using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIMaster : MonoBehaviour
{
    public UIhp hp;
    public UITextBox textBox;
    public Pause pause;
    public Image black;
    public GameObject minimap,map;
    public Camera camera;
    public TMP_Text itemText;
    // Start is called before the first frame update
    void Awake()
    {
        hp = this.GetComponent<UIhp>();
        textBox = this.GetComponent<UITextBox>();
        pause = this.GetComponent<Pause>();
        textBox.Starts();
        hp.Starts();
        pause.Starts();
        itemText.transform.parent.gameObject.SetActive(false);
        Main(true);
        map.SetActive(false);
        DOTween.Sequence().Append(black.DOColor(Color.black, 0))
            .Append(camera.DOFieldOfView(20, 0))
            .AppendInterval(0.2f)
            .Append(black.DOColor(new Color(0, 0, 0, 0), 0.5f))
            .Join(camera.DOFieldOfView(60, 0.8f))
            .AppendCallback(()=>black.gameObject.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey("l"))
        {
            if (Input.GetKeyDown("p"))
            {
                hp.hp -= 1;
            }
            if (Input.GetKeyDown("o"))
            {
                hp.maxHp += 1;

            }

        }
        else 
        {
            if (Input.GetKeyDown("p"))
            {
                hp.hp += 1;

            }
            if (Input.GetKeyDown("o"))
            {
                hp.maxHp -= 1;

            }
        }
        if (Input.GetKeyDown("m"))
        {
            Main(false);
            map.SetActive(true);
        }
        if (Input.GetKeyUp("m"))
        {
            Main(true);
            map.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause.pa)
            {
                pause.Pause_On();
            }
            else
            {
                pause.Pause_Off();
            }
        }
    }
    public void Main(bool a)
    {
        hp.Active(a);
        minimap.SetActive(a);
    }
    public void ItemTextOn(string text)
    {
        itemText.text = text;
        itemText.transform.parent.gameObject.SetActive(true);
    }
    public void ItemTextOff()
    {
        itemText.transform.parent.gameObject.SetActive(false);
    }
}
public class UIBese:MonoBehaviour
{
    public virtual void Active(bool ac) 
    {

    }
}