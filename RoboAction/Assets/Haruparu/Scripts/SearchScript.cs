using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchScript : MonoBehaviour
{
    PlayerScript playerScript;
    string examineText = "\"R\"ÉLÅ[ÇâüÇµÇƒí≤Ç◊ÇÈ";
    public UIMaster ui;
    public string[] text;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();
       // playerScript.ExamineImage.gameObject.SetActive(false);
       // playerScript.ExamineText.gameObject.SetActive(false);
       // playerScript.AfterResearchText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider stayexamine)
    {
        //Debug.Log("called Ontrigger");
        if (stayexamine.gameObject.CompareTag("canexamine"))
        {
            ui.ItemTextOn(examineText);
            if (Input.GetKey(KeyCode.R))
            {
                stayexamine.gameObject.SetActive(false);
                ui.ItemTextOff();
                ui.textBox.A(text,"é©ï™");
                //Invoke(nameof(HideExamineText), 2.5f);
            }
        }
    }

    private void OnTriggerExit(Collider exitexamine)
    {
        if (exitexamine.gameObject.CompareTag("canexamine"))
        {
            //Invoke(nameof(HideItemAllText), 1.5f);
            HideExamineAllText();
        }
    }

    void HideExamineAllText()
    {
        ui.ItemTextOff();
    }

    void HideExamineText()
    {
        playerScript.AfterResearchText.gameObject.SetActive(false);
        playerScript.ExamineImage.gameObject.SetActive(false);
    }
}
