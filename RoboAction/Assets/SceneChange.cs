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
                Debug.LogWarning("\"" + s.ToString() + "\"" + "‚ªŠ„‚èU‚ç‚ê‚½ƒV[ƒ“‚Í‚ ‚è‚Ü‚¹‚ñ");
                return 0;
            }
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.LogWarning("•‰‚Ì”‚ğ“ü—Í‚µ‚È‚¢‚Å‚­‚¾‚³‚¢");
            return 0;
        }
    }
    public int Back()
    {
        sc = before;
        return before;
    }
}
