using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//テキストを保存する方法のテスト用的なやつ
public class UIData : MonoBehaviour
{
    public Dictionary<string, string[]> textBox=new Dictionary<string, string[]>()
    {
        {"npc1",new string[]{"a","i"} }
    };
    // Start is called before the first frame update
    void Start()
    {
        if (!textBox.ContainsKey("npc1")) Debug.Log("npc1が見つかりません");
        Debug.Log(textBox["npc1"][1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
