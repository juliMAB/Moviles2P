using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class GameplayManager : MonoBehaviour
    {
        enum states{ intro, game,end }
        states actualstate;
        [SerializeField] int m_introTime;

        [SerializeField] float m_time;

        [SerializeField] float m_timeToHit;

        private float m_timeToHitF;

        [SerializeField] GameObject ball;

        [SerializeField] GameObject pc;

        [SerializeField] GameObject Intro;

        [SerializeField] GameObject End;

        [SerializeField] GameObject platform;

        [SerializeField] GameplayUI GPUI;

        [SerializeField] public static int oro;

        [SerializeField] public static int time_in_game;

        

        Animator AnimationPc;

        private caracterFXcontroller fXcontroller;

        public float GameTime { get => m_time; set => m_time = value; }
        public GameObject Ball { get => ball; set => ball = value; }
        private void OnEnable()
        {
            IntroManager.OnEndTutorial += changeState;
            EndManager.OnEndGame += changeStateEnd;
            EndManager.OnEndGame += OnSaveScore;
            Intro.SetActive(true);
        }
        public void OnSaveScore()
        {
            DataManager.Get().Gold += oro;
            DataManager.Get().MaxTime = time_in_game;
        }

        private void OnDisable()
        {
            IntroManager.OnEndTutorial -= changeState;
        }

        private void Start()
        {
            if (DataManager.Get()!=null && DataManager.Get().Material!=null)
            {
                ball.SetActive(true);
                ball.GetComponent<Material>().color = DataManager.Get().Material.color;
            }
            AnimationPc = pc.GetComponent<Animator>();
            
            fXcontroller = pc.GetComponent<caracterFXcontroller>();
            m_timeToHitF = m_timeToHit;
            ball.SetActive(false);
            pc.SetActive(false);
            platform.SetActive(false);
        }
        private void Update()
        {
            if (actualstate == states.game)
            {
                m_time += Time.deltaTime;
                m_timeToHitF -= Time.deltaTime;
                GPUI.UpdateTimer((int)m_time);
            if (m_timeToHitF<=0)
            {
                fXcontroller.RandomHit();
                m_timeToHitF = m_timeToHit + Random.Range(-1.0f,1.0f);
            }
            }
        }

        private void changeState()
        {
            actualstate = states.game;
            Invoke(nameof(DisableIntro), 0.1f);
        }
        private void changeStateEnd()
        {
            actualstate = states.end;
            End.SetActive(true);
        }
        void DisableIntro()
        {
            Intro.SetActive(false);
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