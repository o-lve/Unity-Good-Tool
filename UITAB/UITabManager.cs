using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// UGUIҳǩ������
/// 
/// ����������UITabManager
/// ҳǩ��ť����UITabButton
/// ҳǩ���ݹ��ϼ̳���ITabContent�ӿڵĽű�
/// ע����帳ֵ
/// </summary>
public class UITabManager : MonoBehaviour
{
    //ҳǩ��ť�б�
    public List<UITabButton> tabButtonList;
    //ҳǩ�б�
    private List<GameObject> tabContentList = new List<GameObject>();
    //��ǰҳǩ
    //private GameObject curContentObj;
    private UITabButton curButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var one in tabButtonList)
        {
            tabContentList.Add(one.tabContent);
            //Ĭ�ϴ򿪵�һ��
            if (tabContentList.Count == 1)
            {
                curButton = one;
                OpenCurTabContent();
            }
            else
            {
                CloseTabContent(one);
            }

            UGUIEventListener.Get(one.gameObject).OnClick = delegate(PointerEventData eventData)
            {
                //�����ظ����
                if (curButton != one)
                {
                    CloseTabContent(curButton);
                    curButton = one;
                    OpenCurTabContent();
                }
            };
            //one.btn.onClick.AddListener(() =>
            //{

            //});
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�򿪵�ǰҳǩ
    public void OpenCurTabContent()
    {
        if (curButton != null)
        {
            curButton.tabContent.GetComponent<ITabContent>().OpenTabContent();
            curButton.select.SetActive(true);
            curButton.unselect.SetActive(false);
        }
    }

    public void CloseTabContent(UITabButton tabButton)
    {
        tabButton.tabContent.GetComponent<ITabContent>().CloseTabContent();
        tabButton.select.SetActive(false);
        tabButton.unselect.SetActive(true);
    }
}