using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class tekimove : MonoBehaviour
{
    float distance;
    public int hp = 100;
    Animator anim;
    public Transform player;
    public Transform sendouObj;
    public GameObject manageObj;
    public enemymanager mscript;

    public enum EnemyState { Appear, Walk, Battle, Die }
    EnemyState state = EnemyState.Appear;
    string now = "none";
    public bool isAppear = false;
    public bool isWalk = false;
    public string weaponType;
    public int appearType;
    public int group;

    void Start()
    {
        sendouObj = GameObject.Find("sendou.group_" + group.ToString()).transform;
        manageObj = GameObject.Find("manage.group_" + group.ToString());
        mscript = manageObj.GetComponent<enemymanager>();
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
    }
    void FixedUpdate()
    {
        switch (state)
        {
            case EnemyState.Appear:
                if (isAppear == true && now == "none")
                {
                    now = "appear";
                    anim.SetTrigger("Appear" + appearType.ToString());
                }
                else if (isAppear == false)
                {
                    anim.SetTrigger("Idle");
                    state = EnemyState.Walk;
                }
                else if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
                {
                    state = EnemyState.Walk;
                    now = "none";
                }
                break;

            case EnemyState.Walk:
                if (isWalk == true)
                {
                    anim.SetTrigger("Walking");
                    transform.LookAt(new Vector3(sendouObj.position.x, transform.position.y, sendouObj.position.z));
                    transform.position += transform.forward * 0.041f;
                }
                if (Vector3.Distance(player.position, gameObject.transform.position) <= 8 && Physics.Linecast(gameObject.transform.position, player.position, 3) == false)
                {
                    enemymanager.found = true;
                }
                if (enemymanager.found == true)
                {
                    state = EnemyState.Battle;
                }
                break;

            case EnemyState.Battle:
                anim.SetTrigger("Battle");
                if (now == "none")
		    {
                    now = "battle";
                    StartCoroutine("Battle");
                }
                if (hp <= 0)
                {
                    state = EnemyState.Die;
                }
                break;

            case EnemyState.Die:
                if (now == "none")
	          {
                    now = "die";
                    anim.SetTrigger("Die");
                }
                break;
        }
    }
    IEnumerator Battle()
	{
        while (hp >= 1)
        {

            if (anim.GetCurrentAnimatorClipInfo(0)[0].clip is null)
            {
                if (weaponType == "sword")
                {
                    //anim trigger(sword)
                    //wait 0.2 sec
                    //kougekihantei active
                    //wait 0.1s
                    //hantei false
                }

                else if (weaponType == "gun")
                {
                    //anim trigger(gun)
                    //tama tobasu
                }
            }
            yield return null;
        }
	}
}