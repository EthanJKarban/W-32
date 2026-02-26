using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections;


public class WindowPriority : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOMOVE = 0x0002;
    private const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

    void Start()
    {
        // Run this on Start or when you want to trigger the topmost behavior
        SetWindowPos(GetActiveWindow(), HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
    }
    private void Update()
    {
        SetWindowPos(GetActiveWindow(), HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
    }
}