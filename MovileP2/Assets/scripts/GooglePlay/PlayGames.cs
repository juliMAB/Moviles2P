﻿using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Assets.scripts;

public class PlayGames : MonoBehaviourSingleton<PlayGames>
{
    private static string leaderboardID = GPGSIds.leaderboard_score_table;
    private static string achievementID = GPGSIds.achievement_abrir_el_juego;
    private static PlayGamesPlatform platform;

    void Start()
    {
        Init();
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
            UnlockAchievement(achievementID);
        }
    }

    static public void AddScoreToLeaderboard(int score)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(score, leaderboardID, success => { });
        }
    }

    static public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    static public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

    static public void UnlockAchievement(string a)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(a, 100f, success => { });
        }
    }
}