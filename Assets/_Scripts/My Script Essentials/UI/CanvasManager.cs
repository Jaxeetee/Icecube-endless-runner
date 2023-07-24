using System;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] 
    private CanvasController[] _pages;
    public void OpenPage(string pageName)
    {
        CloseAllPages();

        Array.Find(_pages, page => page.pageName == pageName).gameObject.SetActive(true);
    }

    public void ClosePage(string pageName)
    {
        Array.Find(_pages, page => page.pageName == pageName).gameObject.SetActive(false);
    }

    public void CloseAllPages()
    {
        foreach (var page in _pages)
        {
            page.gameObject.SetActive(false);
        }
    }
}
