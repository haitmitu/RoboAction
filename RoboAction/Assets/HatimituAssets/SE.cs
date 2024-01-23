using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public List<GameObject> se=new List<GameObject>();
    public List<string> seNames=new List<string>();
    public string startSEName;
    public float volume;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            StartSE(startSEName);
        }
    }
    //SE呼び出し
    public void StartSE(string seName)
    {
        int seNumber = seNames.IndexOf(seName);
        if (seNumber!=-1)
        {
            GameObject ob = Instantiate(se[seNumber]);
            AudioSource source = ob.GetComponent<AudioSource>();
            source.volume *= volume;
            Destroy(ob, 2f);
        }
        else
        {
            Debug.LogWarning($"SEのリスト内に{seName}という名前のSEはありません");
        }
    }
}
