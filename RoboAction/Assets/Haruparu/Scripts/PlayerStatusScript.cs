using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class PlayerStatusScript : MonoBehaviour
{
    //Animator anim;
    public UnityEvent onDieCallback = new UnityEvent();

    public int life = 100;

    public Slider hpBar;

    void Start()
    {
        //anim = GetComponent<Animator>();

        if (hpBar != null)
        {
            hpBar.value = life;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            //var status = other.GetComponent<PlayerStatusScript>();
            Damage(1);
        }
    }

    public void Damage(int damage)
    {
        if (life <= 0) return;

        life -= damage;
        if (hpBar != null)
        {
            hpBar.value = life;
        }
        if (life <= 0)
        {
            OnDie();
        }
    }

    void OnDie()
    {
        //anim.SetBool("Die", true);
        SceneManager.LoadScene(sceneName: "GameOverScene");
        onDieCallback.Invoke();
    }
}
