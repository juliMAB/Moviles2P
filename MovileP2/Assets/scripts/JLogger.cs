using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLogger
{
    const string PACK_NAME = "com.example.julilogger2";

    const string LOGGER_CLASS_NAME = "JLogger";
    
    const string FILEMANAGER_CLASS_NAME = "FileManager";
    
    static AndroidJavaClass JLoggerClass=null;

    static AndroidJavaObject JLoggerInstance = null;

    static AndroidJavaClass FileManagerClass = null;

    static AndroidJavaObject FileManagerInstance = null;

    


    static void init()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        JLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        JLoggerInstance = JLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
        FileManagerClass = new AndroidJavaClass(PACK_NAME + "." + FILEMANAGER_CLASS_NAME);
        FileManagerInstance = FileManagerClass.CallStatic<AndroidJavaObject>("GetInstance");

        AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
        FileManagerClass.SetStatic<AndroidJavaObject>("myActivity", activity);
#endif
    }
    public static void SendLog(string msg)
    {
#if UNITY_ANDROID && !UNITY_EDITOR  
        if (JLoggerInstance==null)
        {
            init();
        }
        JLoggerInstance.Call("SendLog", msg);
        WriteFile(msg);
#endif
    }
    public static string ReadFile()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (FileManagerInstance == null)
        {
            init();
        }
        return FileManagerInstance.CallStatic<string>("ReadFile", " ");
#else
        return "";
#endif
    }

    private static void WriteFile(string msg)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (FileManagerInstance == null)
        {
            init();
        }
        FileManagerInstance.CallStatic("WriteFile", msg);
#endif
    }


    public static void ClearFile()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (FileManagerInstance == null)
        {
            init();
        }
        FileManagerInstance.CallStatic("ClearFile", " ");
#endif
    }



}
