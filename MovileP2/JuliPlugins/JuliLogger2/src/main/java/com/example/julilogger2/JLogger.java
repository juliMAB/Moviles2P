package com.example.julilogger2;

import android.app.Activity;
import android.util.Log;

public class JLogger {

    public  static  final JLogger _instance = new JLogger();

    public  static  JLogger GetInstance(){
        Log.d("hola","hola");
        return _instance;
    }

    public  void SendLog(String msg){
        Log.d( "JL=>", msg);
    }

}

