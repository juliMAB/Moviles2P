using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGamesController : MonoBehaviour
{
    public void ClearData()
    {
        JLogger.ClearFile();
    }
    public void ShowAchievements()
    {
        PlayGames.ShowAchievements();
    }
    public void ShowLeaderBoard()
    {
        PlayGames.ShowLeaderboard();
    }

    public void UnlickePlayAchivement()
    {
        PlayGames.UnlockAchievement(GPGSIds.achievement_darle_a_play);
    }
}
