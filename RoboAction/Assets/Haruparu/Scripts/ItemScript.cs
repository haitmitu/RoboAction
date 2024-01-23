using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemScript : MonoBehaviour
{
    PlayerScript playerScript;
    public UIMaster ui;
    string itemText= "\"R\"キーを押して拾う";
    string itemGetText= "アイテムを手に入れた";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider hit)
    {
        //Debug.Log(hit); テスト用
        if (hit.gameObject.CompareTag("Item"))
        {
            ui.ItemTextOn(itemText);
            //playerScript.ItemText.gameObject.SetActive(true);
            //playerScript.ItemImage.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                hit.gameObject.SetActive(false);
                ui.ItemTextOn(itemGetText);
                //playerScript.ItemText.gameObject.SetActive(false);
                //playerScript.ItemGetText.gameObject.SetActive(true);
                Invoke(nameof(HideItemText), 2.5f);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            //Invoke(nameof(HideItemAllText), 1.5f);
            HideItemAllText();
        }
    }

    void HideItemAllText()
    {
        ui.ItemTextOff();
        /*playerScript.ItemGetText.gameObject.SetActive(false);
        playerScript.ItemText.gameObject.SetActive(false);
        playerScript.ItemImage.gameObject.SetActive(false);*/
    }

    void HideItemText()
    {
        ui.ItemTextOff();
        /*playerScript.ItemGetText.gameObject.SetActive(false);
        playerScript.ItemImage.gameObject.SetActive(false);*/
    }
}
