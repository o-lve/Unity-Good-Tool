using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// UGUI页签管理器
/// 
/// 管理器挂上UITabManager
/// 页签按钮挂上UITabButton
/// 页签内容挂上继承了ITabContent接口的脚本
/// 注意面板赋值
/// </summary>
public class UITabManager : MonoBehaviour
{
    //页签按钮列表
    public List<UITabButton> tabButtonList;
    //页签列表
    private List<GameObject> tabContentList = new List<GameObject>();
    //当前页签
    //private GameObject curContentObj;
    private UITabButton curButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var one in tabButtonList)
        {
            tabContentList.Add(one.tabContent);
            //默认打开第一个
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
                //避免重复点击
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

    //打开当前页签
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