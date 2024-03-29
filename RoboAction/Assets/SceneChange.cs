using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange scene;
    private int getSc;
    public int sc 
    {
        get 
        {
            return getSc;
        }
        set 
        {
            before = getSc;
            getSc = Change(value);  
        }
    }
    public int scc;
    int before=0;

    // Start is called before the first frame update
    void Awake()
    {
        if (scene == null)
        {
            scene = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
    }
    public int Change(int s)
    {
        if (s>=0)
        {
            if (SceneManager.sceneCountInBuildSettings > s)
            {
                SceneManager.LoadScene(s);
                return s;
            }
            else
            {
                SceneManager.LoadScene(0);
                Debug.LogWarning("\"" + s.ToString() + "\"" + "が割り振られたシーンはありません");
                return 0;
            }
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.LogWarning("負の数を入力しないでください");
            return 0;
        }
    }
    public int Back()
    {
        sc = before;
        return before;
    }
}
