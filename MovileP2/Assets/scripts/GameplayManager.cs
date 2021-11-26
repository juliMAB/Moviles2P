﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class GameplayManager : MonoBehaviour
    {
        enum states{ intro, game }
        states actualstate;
        [SerializeField] int m_introTime;

        [SerializeField] float m_time;

        [SerializeField] float m_timeToHit;

        private float m_timeToHitF;

        [SerializeField] GameObject ball;

        [SerializeField] GameObject pc;

        [SerializeField] GameObject Intro;

        [SerializeField] GameObject platform;

        [SerializeField] GameplayUI GPUI;


        Animator AnimationPc;

        private caracterFXcontroller fXcontroller;

        public float GameTime { get => m_time; set => m_time = value; }
        public GameObject Ball { get => ball; set => ball = value; }
        private void OnEnable()
        {
            IntroManager.OnEndTutorial += changeState;


        }
        private void OnDisable()
        {
            IntroManager.OnEndTutorial -= changeState;
        }

        private void Start()
        {
            if (DataManager.Get()!=null)
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
            Invoke(nameof(DisableIntro), 1);
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