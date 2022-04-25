using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UGUIEventListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, 
    IPointerExitHandler, IPointerUpHandler
{
    public delegate void VoidDelegate(PointerEventData eventData);
    public VoidDelegate OnClick;
    public VoidDelegate OnDown;
    public VoidDelegate OnEnter;
    public VoidDelegate OnExit;
    public VoidDelegate OnUp;
    public VoidDelegate OnSelect;
    public VoidDelegate OnUpdateSelect;

    public static Func<PointerEventData, bool> ClickListenerHandle { get; set; }

    public static UGUIEventListener Get(GameObject go)
    {
        UGUIEventListener listener = go.GetComponent<UGUIEventListener>();
        if (listener == null) listener = go.AddComponent<UGUIEventListener>();
        return listener;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (null != ClickListenerHandle)
        {
            if (!ClickListenerHandle(eventData))
            {
                return;
            }
        }

        OnClick?.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown?.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp?.Invoke(eventData);
    }
    //public void OnSelect(BaseEventData eventData)
    //{
    //    if (onSelect != null) onSelect(eventData);
    //}

    //public void OnUpdateSelected(BaseEventData eventData)
    //{
    //    if (onUpdateSelect != null) onUpdateSelect(eventData);
    //}
    public void SetEventNil()
    {
        OnClick = null;
    }

    public void Coroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }


}
