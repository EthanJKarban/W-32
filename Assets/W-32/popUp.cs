
using System;
using System.Runtime.InteropServices;
using UnityEngine;


public class popUp : MonoBehaviour
{
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)] 

    private static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

    private const uint MB_OK = 0x00000000;
    private const uint MB_OKCANCEL = 0x00000001;   
    private const uint MB_YESNO = 0x00000004;

    private const uint MB_ICONERROR = 0x00000010;
    private const uint MB_ICONQUESTION = 0x00000020;
    private const uint MB_ICONWARNING = 0x00000030;
    private const uint MB_ICONINFORMATION = 0x00000040;

    private const uint IDOK = 1;
    private const uint IDCANCEL = 2;
    private const uint IDYES = 6;
    private const uint IDNO = 7;

    public void ShowExit()
    {
        #if UNITY_STANDALONE_WIN
        uint style = MB_YESNO | MB_ICONQUESTION;
        int result = MessageBox(IntPtr.Zero, "Your leaving?", "Awwww your leaving me?", style);


        if (result == IDYES)
        {
            uint style2 = MB_ICONWARNING | MB_ICONINFORMATION;
            uint style3 = MB_ICONERROR;

            int result2 = MessageBox(IntPtr.Zero, "don't go :<", "Please", style2);
            int result3 = MessageBox(IntPtr.Zero, "don't go :<", "Please", style2);
            int result4 = MessageBox(IntPtr.Zero, "don't go :<", "Please", style2);
            int result5 = MessageBox(IntPtr.Zero, "ok...", "...", style3);

            Application.Quit();
        }
        else if (result == IDNO)
        {
            uint style4 = MB_ICONINFORMATION;
            int result6 = MessageBox(IntPtr.Zero, "Yay! :D", "Thank you!", style4);
            Debug.Log("Surprising");
        }
        #endif
    }
   
}
