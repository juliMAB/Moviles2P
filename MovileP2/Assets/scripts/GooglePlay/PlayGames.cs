using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayGames : MonoBehaviour
{



    public int playerScore;
    string leaderboardID = GPGSIds.leaderboard_score_table;
    string achievementID = GPGSIds.achievement_abrir_el_juego;
    public static PlayGamesPlatform platform;

    void Start()
    {
        Invoke(nameof(Init), 2);
    }
    private void Init()
    {
        
        {
            if (platform == null)
            {
                PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
                PlayGamesPlatform.InitializeInstance(config);
                PlayGamesPlatform.DebugLogEnabled = true;
                platform = PlayGamesPlatform.Activate();
                JLogger.SendLog("PlayGames.cs end platform == null");
            }

            Social.Active.localUser.Authenticate(success =>
            {
                if (success)
                {
                    Debug.Log("Logged in successfully");
                }
                else
                {
                    Debug.Log("Login Failed");
                }
            });
            UnlockAchievement();
        }
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    }
}