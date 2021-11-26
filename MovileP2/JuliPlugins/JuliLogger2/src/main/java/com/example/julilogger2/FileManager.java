package com.example.julilogger2;


import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.util.Log;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.OutputStreamWriter;
import java.io.InputStreamReader;
import java.io.InputStream;
import java.io.IOException;
public class FileManager extends Application {
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

    public static String ReadFile(String a){
        Context context = myActivity.getApplicationContext();

        String ret = "";

        try {
            InputStream inputStream = context.openFileInput("logs");

            if ( inputStream != null ) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString = "";
                StringBuilder stringBuilder = new StringBuilder();

                while ( (receiveString = bufferedReader.readLine()) != null ) {
                    stringBuilder.append("\n").append(receiveString);
                }

                inputStream.close();
                ret = stringBuilder.toString();
            }

            Log.d("JL=>", "Se leyo capo");
        }
        catch (FileNotFoundException e) {
            Log.e("JL=>", "Error: " + e.toString());
        } catch (IOException e) {
            Log.e("JL=>", "Error: " + e.toString());
        }

        return ret;
    }

    public static void ClearFile(String a){
        Context context = myActivity.getApplicationContext();
        context.deleteFile("logs");
        WriteFile("");
    }

}
