using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UITextBox : MonoBehaviour
{
    public GameObject textBox; //会話
    //会話
    public TMP_Text textBox_text, textBox_name;
    private UIhp hp;
    // Start is called before the first frame update
    public void Starts()
    {
        textBox.transform.DOScaleX(0, 0);
    }

    // Update is called once per frame
    public IEnumerator TextBox(string[] text, string name)//(会話文,名前)
    {
        yield return textBox.transform.DOScaleX(2, 0.3f).WaitForCompletion();
        textBox_name.text = name;
        foreach (string t in text)
        {

            textBox_text.text = t;
            yield return new WaitForSeconds(0.4f);
            yield return new WaitUntil(() => Input.GetMouseButton(0));
        }
        textBox_text.text = "";
        textBox_name.text = "";
        textBox.transform.DOScaleX(0, 0.3f).WaitForCompletion();
    }
    public void A(string[] text, string name)//(会話文,名前)
    {
        StartCoroutine(TextBox(text, name));
    }
}
