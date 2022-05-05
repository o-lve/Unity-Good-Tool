using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// % Ctrl  # Shift & Alt
/// </summary>
public class NoRaycastTarget : MonoBehaviour
{
    /// <summary>
    /// �Զ�ȡ��RatcastTarget
    /// </summary>
    [MenuItem("GameObject/UI/Image %#I")]
    static void CreatImage()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                GameObject go = new GameObject("Image", typeof(Image));
                go.GetComponent<Image>().raycastTarget = false;
                go.transform.SetParent(Selection.activeTransform);
                go.transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            Canvas canvas = CheckHasCanvas();
            if (canvas != null)
            {
                GameObject go = new GameObject("Image", typeof(Image));
                go.GetComponent<Image>().raycastTarget = false;
                go.transform.SetParent(canvas.transform);
                go.transform.localPosition = Vector3.zero;
            }
        }
    }
    //��дCreate->UI->Text�¼�  
    [MenuItem("GameObject/UI/Text %#T")]
    static void CreatText()
    {
        if (Selection.activeTransform)
        {
            //���ѡ�е����б����Canvas  
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                //�½�Text����  
                GameObject go = new GameObject("Text", typeof(Text));
                //��raycastTarget��Ϊfalse  
                go.GetComponent<Text>().raycastTarget = false;
                //�����丸����  
                go.transform.SetParent(Selection.activeTransform);
                go.transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            Canvas canvas = CheckHasCanvas();
            if (canvas != null)
            {
                GameObject go = new GameObject("Text", typeof(Text));
                go.GetComponent<Text>().raycastTarget = false;
                go.transform.SetParent(canvas.transform);
                go.transform.localPosition = Vector3.zero;
            }
        }
    }

    //��дCreate->UI->Text�¼�  
    [MenuItem("GameObject/UI/Raw Image %#R")]
    static void CreatRawImage()
    {
        if (Selection.activeTransform)
        {
            //���ѡ�е����б����Canvas  
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                //�½�Text����  
                GameObject go = new GameObject("RawImage", typeof(RawImage));
                //��raycastTarget��Ϊfalse  
                go.GetComponent<RawImage>().raycastTarget = false;
                //�����丸����  
                go.transform.SetParent(Selection.activeTransform);
                go.transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            Canvas canvas = CheckHasCanvas();
            if (canvas != null)
            {
                GameObject go = new GameObject("RawImage", typeof(RawImage));
                go.GetComponent<RawImage>().raycastTarget = false;
                go.transform.SetParent(canvas.transform);
                go.transform.localPosition = Vector3.zero;
            }
        }
    }
    /// <summary>
    /// ����û��ѡ������ʱ����
    /// </summary>
    /// <returns></returns>
    static Canvas CheckHasCanvas()
    {
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject go = new GameObject("Canvas");
            canvas = go.AddComponent<Canvas>();
            go.AddComponent<CanvasScaler>();
            go.AddComponent<GraphicRaycaster>();
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
            eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }
        return canvas;
    }
}

[InitializeOnLoad]
public class Factory
{
    static Factory()
    {
        ObjectFactory.componentWasAdded += ComponentWasAdded;
    }

    private static void ComponentWasAdded(Component component)
    {
        Image image = component as Image;
        if (image != null)
            image.raycastTarget = false;
        RawImage rawImage = component as RawImage;
        if (rawImage != null)
            rawImage.raycastTarget = false;
        Text text = component as Text;
        if (text != null)
            text.raycastTarget = false;
    }
}