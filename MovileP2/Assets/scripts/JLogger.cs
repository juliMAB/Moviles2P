using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLogger
{
    const string PACK_NAME = "com.example.julilogger2";

    const string LOGGER_CLASS_NAME = "JLogger";
    
    static AndroidJavaClass JLoggerClass=null;

    static AndroidJavaObject JLoggerInstance = null;


    static void init()
    {
        JLoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        JLoggerInstance = JLoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
    }
    public static void SendLog(string msg)
    {
        if (JLoggerInstance==null)
        {
            init();
        }
        JLoggerInstance.Call("SendLog", msg);
    }
}
