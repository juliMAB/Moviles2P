package com.example.julilogger2;


import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.facebook.CallbackManager;
import com.facebook.FacebookCallback;
import com.facebook.FacebookException;
import com.facebook.FacebookSdk;
import com.facebook.login.LoginResult;
import com.facebook.login.widget.LoginButton;
import com.facebook.share.model.ShareHashtag;
import com.facebook.share.model.ShareLinkContent;
import com.facebook.share.model.SharePhoto;
import com.facebook.share.model.SharePhotoContent;
import com.facebook.share.widget.ShareButton;

public class FacebookClass  extends AppCompatActivity {


    public  static  final FacebookClass _instance = new FacebookClass();

    public  static  FacebookClass GetInstance(){
        return _instance;
    }

    public static Activity unityActivity;

   public  static void reciveUnityActivity(Activity tActivity)
   {
       unityActivity = tActivity;
   }


    private TextView info;
    private LoginButton loginButton;
    private CallbackManager callbackManager;
    private ShareButton sbLink;
    private ShareButton sbPhoto;
    private ImageView imageView;


    protected void onCreate(Bundle savedInstanceState) {
        //Context mycontext = myActivity.getApplicationContext();
        super.onCreate(savedInstanceState);

        //setContentView(R.layout.unityActivity);
        int DisplayId = 0;
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.R) {
            DisplayId = unityActivity.getDisplay().getDisplayId();
        }
        setContentView(DisplayId);

        FacebookSdk.sdkInitialize(getApplicationContext());


        callbackManager = CallbackManager.Factory.create();

        setContentView(DisplayId);
        info = (TextView)findViewById(R.id.info);
        loginButton = (LoginButton)findViewById(0);

        loginButton.registerCallback(callbackManager, new FacebookCallback<LoginResult>() {
            @Override
            public void onSuccess(LoginResult loginResult) {
                info.setText("User ID: " + loginResult.getAccessToken().getUserId() + "\n" + "Auth Token: " + loginResult.getAccessToken().getToken());
                JLogger.GetInstance().SendLog(info.toString());
            }

            @Override
            public void onCancel() {
                info.setText("Login attempt canceled.");
                JLogger.GetInstance().SendLog(info.toString());
            }

            @Override
            public void onError(FacebookException e) {
                info.setText("Login attempt failed.");
                JLogger.GetInstance().SendLog(info.toString());
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode , resultCode , data);

        callbackManager.onActivityResult(requestCode, resultCode, data);

        ShareLinkContent shareLinkContent = new ShareLinkContent.Builder()
                .setContentUrl(Uri.parse("https://www.youtube.com/watch?v=XyG43hMToR8"))
                .setShareHashtag( new ShareHashtag.Builder()
                        .setHashtag("#JuliPlugins").build())
                .build();

        sbLink.setShareContent(shareLinkContent);

        BitmapDrawable bitmapDrawable = (BitmapDrawable) imageView.getDrawable();
        Bitmap bitmap = bitmapDrawable.getBitmap();

        SharePhoto sharePhoto = new SharePhoto.Builder()
                .setBitmap(bitmap)
                .build();
        SharePhotoContent sharePhotoContent = new SharePhotoContent.Builder()
                .addPhoto(sharePhoto)
                .build();

        sbPhoto.setShareContent(sharePhotoContent);
    }
}
