using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections;


public class WindowPriority : MonoBehaviour
{
    [DllImport("user32.dll")]

    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    private static extern IntPtr GetActiveWindow();

    
    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_NOSIZE = 0x0001;
    private static readonly IntPtr HWND_TOPMOST = new(-1);
    void Start()
    {
        // This functionality only works in a built Windows application, not within the Unity Editor itself
        if (!Application.isEditor)
        {
            SetWindowAlwaysOnTop();
        }
    }

    public void SetWindowAlwaysOnTop()
    {
        IntPtr windowHandle = GetActiveWindow();
        if (windowHandle != IntPtr.Zero)
        {
            // Set the window position to "always on top" (HWND_TOPMOST)
            SetWindowPos(windowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
        }
    }
}
