using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject pc;

    [SerializeField] GameObject ball;

    [SerializeField] GameObject canvasIntro;

    [SerializeField] GameObject platform;

    [SerializeField] GameObject panel;

    [SerializeField] UI_Asistans UI_Asistans;

    [SerializeField] int index=0;



    public static System.Action OnEndTutorial;

    public void UpdateIntro()
    {
        index++;
        if (index == 1)
            panel.GetComponent<Animator>().Play("a");
        else if (index >1 && index<=UI_Asistans.MaxMessage)
        {
            UI_Asistans.OnIndexChange(index - 1);
            UI_Asistans.OnButton(index-1);
            if (index - 1 == 2)
            {
                platform.SetActive(true);
            }
            else if (index - 1 == 4)
            {
                ball.SetActive(true);
            }
            else if (index - 1 == 5)
            {
                pc.SetActive(true);
            }
            else if (index - 1 == 9)
            {
                pc.GetComponent<Animator>().Play("Start1");
            }
            else if (index - 1 == 10)
            {
                Debug.Log("OnEndIntro");
                OnEndTutorial?.Invoke();
            }
        }
    }
    public void skipTutorial()
    {
        ball.SetActive(true);
        platform.SetActive(true);
        pc.SetActive(true);
        OnEndTutorial?.Invoke();
    }
}
