using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;
using JetBrains.Annotations;
// Note to self: This is for me to learn it fully.
public class WindowMover : MonoBehaviour
{
   
    public int targetWidth = 800;
    public int targetHeight = 600;

    // DllImport for user32.dll functions
    [DllImport("user32.dll", EntryPoint = "MoveWindow")]
    private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetSystemMetrics(int nIndex);
    



    // Constants for GetSystemMetrics
    private const int SM_CXSCREEN = 0;
    private const int SM_CYSCREEN = 1;

    private IntPtr windowHandle;
    public int windowWidth;
    public int windowHeight;

    private void Awake()
    {
        
        Screen.SetResolution(targetWidth, targetHeight, false);
        
    }
    void Start()
    {
        // Get the handle to the current window
        windowHandle = GetActiveWindow();

        if (windowHandle != IntPtr.Zero)
        {
            Screen.fullScreen = false;
            // Set the window to a known initial size for consistent movement
            targetWidth = Screen.width;
            targetHeight = Screen.height;
            MoveWindow(windowHandle, 0, 0, targetWidth, targetHeight, true);

            // Start the random movement coroutine
            StartCoroutine(RandomlyMoveWindow());
        }
    }

    IEnumerator RandomlyMoveWindow()
    {
        while (true)
        {
           

            // Get screen dimensions
            int screenWidth = GetSystemMetrics(SM_CXSCREEN);
            int screenHeight = GetSystemMetrics(SM_CYSCREEN);

            // Calculate random coordinates within screen boundaries
            // We subtract window dimensions to keep the entire window visible
            int randomX = UnityEngine.Random.Range(0, screenWidth - windowWidth);
            int randomY = UnityEngine.Random.Range(0, screenHeight - windowHeight);

            float delay = UnityEngine.Random.Range(3f, 5f);
            // Move the window to the new random position
            MoveWindow(windowHandle, randomX, randomY, windowWidth, windowHeight, true);

            // Wait for a random duration before moving again

            //float moveDelay = UnityEngine.Random.Range(0, 3);
            yield return new WaitForSeconds(delay);
        }
    }
     public void clicked()
    {

        // Get screen dimensions
        int screenWidth = GetSystemMetrics(SM_CXSCREEN);
        int screenHeight = GetSystemMetrics(SM_CYSCREEN);

        // Calculate random coordinates within screen boundaries
        // We subtract window dimensions to keep the entire window visible
        int randomX = UnityEngine.Random.Range(0, screenWidth - windowWidth);
        int randomY = UnityEngine.Random.Range(0, screenHeight - windowHeight);

        //float delay = UnityEngine.Random.Range(3f, 5f);
        // Move the window to the new random position
        MoveWindow(windowHandle, randomX, randomY, windowWidth, windowHeight, true);

        // Wait for a random duration before moving again

        //float moveDelay = UnityEngine.Random.Range(0, 3);
        
    }
   
}

