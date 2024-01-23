using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor;

public class ButtonP : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject waku;
    // Start is called before the first frame update
    void Start()
    {
        waku.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        waku.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        waku.SetActive(false);
    }
}