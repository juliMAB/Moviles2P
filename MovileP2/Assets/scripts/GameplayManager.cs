using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class GameplayManager : MonoBehaviourSingleton<GameplayManager>
    {
        enum states{ intro, game }
        states actualstate;
        [SerializeField] int m_introTime;

        [SerializeField] float m_time;

        [SerializeField] GameObject ball;

        [SerializeField] GameObject pc;

        [SerializeField] UI_Asistans UI_Asistans;

        Animator AnimationPc;

        const float m_StartTime = 60;


        public float GameTime { get => m_time; set => m_time = value; }


        private void Start()
        {
            AnimationPc = pc.GetComponent<Animator>();
            m_time = m_StartTime;
            UI_Asistans.onIndexChange += acepter;
        }
        private void Update()
        {
            if (actualstate == states.game)
            {
                m_time -= Time.deltaTime;
            }
        }
        private void acepter(int index)
        {
            if (index==3)
            {
                ball.SetActive(true);
            }
            if (index==8)
            {
                AnimationPc.Play("Start1");
                actualstate = states.game;
            }
        }

    }
}