using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor;

public class ButtonDO : UIBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public RectTransform bIm;
    public TMP_Text text;
    int a=1;
    public int sc 
    {
        set
        {
            SceneChange.scene.sc = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        var sp = DOTween.Sequence();
        sp.Append(bIm.DOLocalMove(Vector3.zero, 0.08f))
            .AppendCallback(() => {
                text.color = Color.white;
                a *= -1;
                });
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        var sp = DOTween.Sequence();
        sp.Append(bIm.DOLocalMoveX(555* a, 0.08f))
            .AppendCallback(() => text.color = Color.black);
    }
}
