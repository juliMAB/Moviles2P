using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAchivement : MonoBehaviour
{
    public void crazyFunk()
    {
        PlayGamesScript.UnlockAchievement(GPGSIds.achievement_abrir_el_juego);
        PlayGamesScript.ShowAchievementsUI();
    }
    public void ShowAUI()
    {
        PlayGamesScript.ShowAchievementsUI();
    }
}
