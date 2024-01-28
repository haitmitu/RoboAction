using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIhp : MonoBehaviour
{
    public GameObject hpM;

    public GameObject heart;
    public List<Image> hearts = new List<Image>();
    private int getHp;
    public Sprite[] image;
    //hp
    public int hp
    {
        get
        {
            return getHp;
        }
        set
        {
            if (getHp != value)
            {
                getHp = value;
                HP();
                Debug.Log(value);
            }
        }
    }
    //MaxHp
    private int getMaxHp;
    public int maxHp
    {
        get
        {
            return getMaxHp;
        }
        set
        {
            if (getMaxHp != value)
            {
                if (getMaxHp < value)
                {
                    getMaxHp = value;
                    AddMaxHp();
                }
                else
                {
                    getMaxHp = value;
                    SubtractMaxHp();
                }
            }
        }
    }
    // Start is called before the first frame update
    public void Starts()
    {
    }
    public void HP()
    {
        for (int i = 0; i < maxHp; i++)
        {
            if (hp <= i)
            {
                if (hearts[i].sprite == image[1])
                {
                    StartCoroutine(HPAnimation(hearts[i].rectTransform, 0, i));
                }
                else
                {
                    hearts[i].sprite = image[0];
                }
            }
            else
            {
                if (hearts[i].sprite == image[0])
                {
                    StartCoroutine(HPAnimation(hearts[i].rectTransform, 1, i));
                }
                else
                {
                    hearts[i].sprite = image[1];
                }
            }
        }

    }
    //MaxHP‘‰ÁŽž
    public void AddMaxHp()
    {
        for (int i = (hearts.Count + 1); i <= maxHp; i++)
        {
            GameObject game = Instantiate(heart);
            RectTransform rect = game.GetComponent<RectTransform>();
            rect.position += new Vector3(20, 0, 0) * i;
            Image im = game.GetComponent<Image>();
            im.sprite = image[1];
            hearts.Add(im);
            DOTween.Sequence()
            .AppendInterval(0.2f)
            .AppendCallback(() => rect.SetParent(hpM.transform))
            .AppendInterval(0.1f)
            .Append(rect.DOScale(Vector3.one * 3.9f, 0.5f).SetEase(Ease.OutQuart))
            .AppendInterval(0.1f)
            .Append(rect.DOScale(Vector3.one*3f, 0.2f).SetEase(Ease.InOutSine));
        }
        hp = maxHp;
    }
    public IEnumerator HPAnimation(RectTransform hpT, int n, int im)
    {
        var sp = DOTween.Sequence();
        switch (n)
        {
            //hpŒ¸­
            case 0:
                sp.AppendInterval(0.1f)
                    .Append(hearts[im].DOColor(Color.red, 0.0f))
                    .AppendCallback(() => { hearts[im].sprite = image[0]; })
                    .Append(hpT.DOScale(Vector3.one * 3.6f, 0.4f))
                    .Join(hearts[im].DOColor(new Color(0, 0, 0, 1f), 0.4f))
                    .AppendCallback(() => {
                        hearts[im].color = new Color(1, 1, 1, 1);
                    })
                    .Append(hpT.DOScale(Vector3.one * 3.0f, 0.2f));
                break;
            //hp‰ñ•œ
            case 1:
                sp.AppendInterval(0.1f)
                    .Append(hearts[im].DOColor(new Color(0, 0, 0, 0.4f), 0.0f))
                    .AppendCallback(() => { hearts[im].sprite = image[1]; })
                    .Append(hpT.DOScale(Vector3.one*3.6f, 0.4f))
                    .Join(hearts[im].DOColor(Color.red, 0.4f))
                    .AppendCallback(() => {
                        hearts[im].color = new Color(1, 1, 1, 1);
                    })
                    .Append(hpT.DOScale(Vector3.one * 3.0f, 0.2f));
                break;
        }
        yield return null;
    }
    //MaxHPŒ¸­Žž
    public void SubtractMaxHp()
    {
        int he = hearts.Count;
        if (he - maxHp > 0)
        {
            for (int i = 0; i < (he - maxHp); i++)
            {
                int h = (he - 1) - i;
                GameObject g = hearts[h].gameObject;
                hearts.RemoveAt(h);
                Destroy(g);
            }
        }
    }
    public void Active(bool ac) 
    {
        hpM.SetActive(ac); 
    }

}
