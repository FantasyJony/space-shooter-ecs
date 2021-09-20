// GENERATED AUTOMATICALLY FROM 'Assets/EcsSpaceShooter/Res/InputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace SpaceShooter
{
    public class @ShooterInputAction : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ShooterInputAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAction"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""d6c9c378-3d7f-4040-bcfa-c847cbadf4d0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""975c11ad-840e-47fd-a5bf-d812e8b8cb1d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""8d00a5e4-2e1f-49d0-8891-275e38657373"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fb578ff6-0ab1-4a40-a3bf-02719c90413d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard-WASD"",
                    ""id"": ""edfff4d3-1902-4152-9608-c07b8b3fc265"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a4f95b0e-5bc8-46c9-b246-09e2a108d282"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c6138609-58d3-4513-b492-f253eafdcff1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5029a926-bf26-43be-9706-b2db5c10cdb0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89af08e8-2b2a-4e34-a185-be00c30a00f1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6527492f-ea0a-4f80-89bc-f5e8648f38cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e252e5e5-ca03-416b-9f1b-7ef7be463224"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": []
        }
    ]
}");
            // gameplay
            m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
            m_gameplay_Movement = m_gameplay.FindAction("Movement", throwIfNotFound: true);
            m_gameplay_Fire = m_gameplay.FindAction("Fire", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // gameplay
        private readonly InputActionMap m_gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_gameplay_Movement;
        private readonly InputAction m_gameplay_Fire;
        public struct GameplayActions
        {
            private @ShooterInputAction m_Wrapper;
            public GameplayActions(@ShooterInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_gameplay_Movement;
            public InputAction @Fire => m_Wrapper.m_gameplay_Fire;
            public InputActionMap Get() { return m_Wrapper.m_gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                }
            }
        }
        public GameplayActions @gameplay => new GameplayActions(this);
        private int m_KeyboardAndMouseSchemeIndex = -1;
        public InputControlScheme KeyboardAndMouseScheme
        {
            get
            {
                if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
                return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
            }
        }
        public interface IGameplayActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
        }
    }
}
