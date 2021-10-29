using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class GameplayManager : MonoBehaviourSingleton<GameplayManager>
    {
        [SerializeField] int m_introTime;

        [SerializeField] float m_time;

        const float m_StartTime = 60;

        public float GameTime { get => m_time; set => m_time = value; }

        private void Start()
        {
            m_time = m_StartTime;
        }
        private void Update()
        {
            m_time -= Time.deltaTime;
        }
    }
}