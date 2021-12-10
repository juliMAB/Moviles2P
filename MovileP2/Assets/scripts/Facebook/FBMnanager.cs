using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System;
using TMPro;

public class FBMnanager : MonoBehaviour
{

    // public GameObject Panel_Add;

    public TextMeshProUGUI FB_userName;

    public Image FB_useerDp;

    public GameObject friendstxtprefab;

    public GameObject GetFriendsPos;

    public Image FacebookImage;

    public string respuesta;

    public string url = "";

    public TMPro.TextMeshProUGUI link;

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    multiCallLogs("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
            multiCallLogs("Facebook is Login!");
        else
            multiCallLogs("Facebook is not Logged in!");
        DealWithFbMenus(FB.IsLoggedIn);
    }



    void onHidenUnity(bool isGameShown)
    {
        if (!isGameShown)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void FBLogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        permissions.Add("user_friends");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }



    public void CallLogout()
    {
        StartCoroutine("FBLogout");
    }

    private IEnumerator FBLogout(){
        FB.LogOut();
        while (FB.IsLoggedIn){
            JLogger.SendLog("Logging Out");
            yield return null;
        }
        JLogger.SendLog("Logout Successful");
        FB_useerDp.sprite = FacebookImage.sprite;
        FB_userName.text = "";
    }





    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
        {
            Debug.Log("the raw" + result.RawResult);

            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);

            var friendsList = (List<object>)dictionary["data"];


            foreach (var dict in friendsList) {

                GameObject go = Instantiate(friendstxtprefab);

                go.GetComponent<Text>().text = ((Dictionary<string, object>)dict)["name"].ToString();

                go.transform.SetParent(GetFriendsPos.transform, false);
            }
        });
    }

    void AuthCallBack(IResult result){
        if (result.Error != null)
            multiCallLogs(result.Error);
        else
        {
            if (FB.IsLoggedIn)
                multiCallLogs("Facebook is Login!");
            else
                multiCallLogs("Facebook is not Logged!");
            DealWithFbMenus(FB.IsLoggedIn);
        }
    }

    void multiCallLogs(string text)
    {
        Debug.Log(text);
        JLogger.SendLog(text);
    }


    void DealWithFbMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
        }
    }
    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            FB_userName.text = "" + result.ResultDictionary["first_name"];
            multiCallLogs(FB_userName.text);
        }
        else
            multiCallLogs(result.Error);
    }



    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Debug.Log("Profile Pic");
            FB_useerDp.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
        else
            multiCallLogs(result.Error);
    }

    //shared.
    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("https://play.google.com/store/apps/details?id=com.AguirreJulian.BadPc"), "Check it out!",
            "Nice Game!", new System.Uri("https://imgur.com/a/1sANcUn"));
    }
    //invite.
    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game!", title: "BAD PC");
    }

    private void RespuestaShared(IShareResult x)
    {
        respuesta = "Shared ";
        JLogger.SendLog(respuesta + x);
    }
    private void RespuestaGR(IGraphResult x)
    {
        respuesta = "APIGRAPH ";
        JLogger.SendLog(respuesta + x);
    }


    public void FacebookApiGet()
    {
        FacebookApi(HttpMethod.GET);
    }
    public void FacebookApiSave()
    {
        FacebookApi(HttpMethod.POST);
    }
    public void FacebookApiDelete()
    {
        FacebookApi(HttpMethod.DELETE);
    }
    //Graph save. Load. Delete.
    public void FacebookApi(HttpMethod method)
    {
        WWWForm form = new WWWForm();
        IDictionary<string, string> a = null;
        int gold = DataManager.Get().Gold;
        a.Add("score", gold.ToString());
        FB.API("score", method, callback: RespuestaGR, a);
    }
    //appEvent. si es log pero es appEvent.
    public void FBLog(string text)
    {
        Dictionary<string, object> a = null;
        FB.LogAppEvent("FBLoger=> " + text, 1, a);
    }
    //share
    public void ShareProgress()
    {
        FB.AppRequest("I Just got " + DataManager.Get().MaxTime.ToString() + " Time! Can you beat it?", OGActionType.SEND, null, null,
            "{\"challenge_Time\":" + DataManager.Get().MaxTime.ToString() + "}", "Friend Smash Challenge!", callback: RespuestaRR);
    }
    private void RespuestaRR(IAppRequestResult x)
    {
        respuesta = "RR: ";
        JLogger.SendLog(respuesta + x);
    }
    
    public void GetAppLink()
    {
        FBLog("se obtuvo el link");
        FB.GetAppLink(DeepLinkCallback);
    }
    void DeepLinkCallback(IAppLinkResult result)
    {
        if (!String.IsNullOrEmpty(result.Url))
        {
            var index = (new Uri(result.Url)).Query.IndexOf("request_ids");
            if (index != -1)
            {
                url = result.Url;
                // ...have the user interact with the friend who sent the request,
                // perhaps by showing them the gift they were given, taking them
                // to their turn in the game with that friend, etc.
            }
        }
    }
}