using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class TitleChange : MonoBehaviour
{
    [DllImport("user32.dll", EntryPoint = "SetWindowText")]
    public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);

    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    public static extern System.IntPtr FindWindow(System.String className, System.String windowName);

    public string newWindowTitle = "Just keep clickin";
    public string[] clickedWindowTitle;
    public string leavingSoSoon = "Leaving so soon? :<";

    private IntPtr windowPtr;

    private void Awake()
    {
        windowPtr = FindWindow(null, Application.productName);
    }

    void Start()
    {
        SetWindowText(windowPtr, newWindowTitle);
    }

    public void ClickTitle()
    {
        SetWindowText(windowPtr, clickedWindowTitle[UnityEngine.Random.Range(0, clickedWindowTitle.Length)]);
    }

    public void LeaveTitle()
    {
        SetWindowText(windowPtr, leavingSoSoon);
    }
}
