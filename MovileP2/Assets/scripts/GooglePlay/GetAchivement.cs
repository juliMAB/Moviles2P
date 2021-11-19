using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAchivement : MonoBehaviour
{
    [SerializeField] PlayGames pg;

    public void crazyFunk()
    {
        //pg.UnlockAchievement(GPGSIds.achievement_abrir_el_juego);
        //pg.ShowAchievementsUI();
    }
    public void ShowAUI()
    {
        pg.ShowAchievements();
    }
}
