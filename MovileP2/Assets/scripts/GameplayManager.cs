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

        [SerializeField] money[] cubosOro;

        Animator AnimationPc;

        private caracterFXcontroller fXcontroller;

        public float GameTime { get => m_time; set => m_time = value; }
        public GameObject Ball { get => ball; set => ball = value; }

        bool[] progression = new bool[10];
        private void Awake()
        {
            JLogger.SendLog("Iniciar Gameplay");
            for (int i = 0; i < progression.Length; i++)
            {
                progression[i] = false;
            }

            for (int i = 0; i < cubosOro.Length; i++)
            {
                cubosOro[i].OnGetMoney += UpdateOro;
            }
        }

        public void UpdateOro()
        {
            GPUI.UpdateOro(oro);
            JLogger.SendLog("Recogiste 1 oro");
        }

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
            JLogger.SendLog("SaveData on DataManeger");
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
                if (m_timeToHitF <= 0)
                {
                    fXcontroller.RandomHit();
                    m_timeToHitF = m_timeToHit + Random.Range(-1.0f, 1.0f);
                }
                if (m_time>10&&!progression[0])
                {
                    progression[0] = true;
                    m_timeToHit = 2.5f;
                    PlayGames.UnlockAchievement(GPGSIds.achievement_durar_10_segundos);
                }
                else if (m_time > 30 && !progression[1])
                {
                    progression[1] = true;
                    m_timeToHit = 2.5f;
                    AnimationPc.SetFloat("speedAtacks", 1.5f);
                    PlayGames.UnlockAchievement(GPGSIds.achievement_llegar_a_20_segundos);
                }
                else if (m_time > 60 && !progression[2])
                {
                    progression[2] = true;
                    m_timeToHit = 2f;
                    AnimationPc.SetFloat("speedAtacks", 1.75f);
                    PlayGames.UnlockAchievement(GPGSIds.achievement_llegar_a_los_60_segundos);
                }
                else if (m_time > 60 && !progression[3])
                {
                    progression[3] = true;
                    m_timeToHit = 1;
                    AnimationPc.SetFloat("speedAtacks", 2.5f);
                    PlayGames.UnlockAchievement(GPGSIds.achievement_llegar_a_los_2_minutos_todo_un_tryhard);
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
            PlayGames.AddScoreToLeaderboard(time_in_game);
            JLogger.SendLog("Perdiste.");
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