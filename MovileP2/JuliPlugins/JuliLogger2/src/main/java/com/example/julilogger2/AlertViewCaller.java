package com.example.julilogger2;


import android.app.Activity;
import android.content.Context;
import android.util.Log;

import java.io.IOException;
import java.io.OutputStreamWriter;

public class AlertViewCaller {

    public  static  final FileManager _instance = new FileManager();

    public  static  FileManager GetInstance(){
        return _instance;
    }

    public static Activity myActivity;

    public static void WriteFile(String a){
        Context mycontext = myActivity.getApplicationContext();
        try {
            OutputStreamWriter outputStreamWriter= new OutputStreamWriter(mycontext.openFileOutput("logs", Context.MODE_APPEND));

            outputStreamWriter.write(a + "\n");
            outputStreamWriter.close();

            Log.d("JL=>", "Wrote succesfully");
        }
        catch (IOException e) {
            Log.e("JL=>", "error: " +e.toString());
        }
    }

}
