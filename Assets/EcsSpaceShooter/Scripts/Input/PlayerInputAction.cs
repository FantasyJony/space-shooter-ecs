using System;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public class PlayerInputAction : MonoBehaviour, ShooterInputAction.IGameplayActions
    {
        [SerializeField] private float m_FireRate;
        private float m_NextFire;

        public static PlayerInputAction Instance { get; private set; }
        private ShooterInputAction m_ShooterInputAction;

        private float m_HorizontalValue;
        private float m_VerticalValue;
        private bool m_Fire;

        public float horizontalValue => m_HorizontalValue;
        public float verticalValue => m_VerticalValue;
        public bool fire => m_Fire;

        public bool fireSound
        {
            get
            {
                if (m_Fire && Time.time >= m_NextFire)
                {
                    m_NextFire = Time.time + m_FireRate;
                    return true;
                }
                return false;
            }
        }

        private void Start()
        {
            Instance = this;
        }

        private void InitShooterInputAction()
        {
            if (m_ShooterInputAction == null)
            {
                m_ShooterInputAction = new ShooterInputAction();
                m_ShooterInputAction.gameplay.SetCallbacks(this);
            }
        }

        private void OnEnable()
        {
            InitShooterInputAction();
            m_ShooterInputAction.gameplay.Enable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                {
                    var movement = context.ReadValue<Vector2>();
                    m_HorizontalValue = movement.x;
                    m_VerticalValue = movement.y;
                }
                    break;

                case InputActionPhase.Canceled:
                {
                    m_HorizontalValue = 0f;
                    m_VerticalValue = 0;
                }
                    break;
            }
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                {
                    m_Fire = true;
                }
                    break;

                case InputActionPhase.Canceled:
                {
                    m_Fire = false;
                }
                    break;
            }
        }
    }
}