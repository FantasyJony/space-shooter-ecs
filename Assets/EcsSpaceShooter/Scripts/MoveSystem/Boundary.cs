using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [Serializable]
    public class Boundary : MonoBehaviour
    {
        [SerializeField] private float m_XMin;
        [SerializeField] private float m_XMax;
        [SerializeField] private float m_YMin;
        [SerializeField] private float m_YMax;

        private static Boundary s_Instance;

        public static float xMin => s_Instance.m_XMin;
        public static float xMax => s_Instance.m_XMax;
        public static float yMin => s_Instance.m_YMin;
        public static float yMax => s_Instance.m_YMax;

        private void Start()
        {
            s_Instance = this;
        }
    }
}
