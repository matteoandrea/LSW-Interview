using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    private TabButton _selectedTab;

    [Space(20)]

    public List<GameObject> objSwap;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (_selectedTab == null || button != _selectedTab)
            button.backgorund.sprite = tabHover;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (_selectedTab != null) _selectedTab.Deselect();
        _selectedTab = button;
        _selectedTab.Select();

        ResetTabs();
        
        button.backgorund.sprite = tabActive;

        var index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objSwap.Count; i++)
        {
            if (i == index) objSwap[i].SetActive(true);

            else objSwap[i].SetActive(false);
        }
    }

    public void ResetTabs()
    {
        foreach (var button in tabButtons)
        {
            if (_selectedTab != null && button == _selectedTab) continue;

            button.backgorund.sprite = tabIdle;
        }
    }


}
