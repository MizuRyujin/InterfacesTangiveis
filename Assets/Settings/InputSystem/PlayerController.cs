// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputSystem/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""FlightActions"",
            ""id"": ""6fff86af-f0ce-4e7b-aca8-36923b858b2c"",
            ""actions"": [
                {
                    ""name"": ""MovementControl"",
                    ""type"": ""PassThrough"",
                    ""id"": ""450e6772-366e-4585-85e8-c0cefd3937e8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LiftOff"",
                    ""type"": ""Button"",
                    ""id"": ""722fe00c-33e4-4b62-a0cb-9c5d2e2ab552"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3ca34c57-aa94-4e9b-a689-22a6afa65531"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LiftOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc8b4b77-073f-4da5-85a1-c936ede2e3af"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LiftOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""1e22cbcd-6cbb-4908-8af7-dbe0b7c0f912"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3994e61b-0584-4fab-ad63-470b0a8f12cb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b48eb01d-d756-4943-8e8e-3c17bf97a4f2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5067bc98-09dc-4ed3-8eb9-c55c48208db4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02f561a7-7810-4724-bd7a-995630ee0393"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a7ae97b4-ea09-4757-9381-b7ceb25a83cb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // FlightActions
        m_FlightActions = asset.FindActionMap("FlightActions", throwIfNotFound: true);
        m_FlightActions_MovementControl = m_FlightActions.FindAction("MovementControl", throwIfNotFound: true);
        m_FlightActions_LiftOff = m_FlightActions.FindAction("LiftOff", throwIfNotFound: true);
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

    // FlightActions
    private readonly InputActionMap m_FlightActions;
    private IFlightActionsActions m_FlightActionsActionsCallbackInterface;
    private readonly InputAction m_FlightActions_MovementControl;
    private readonly InputAction m_FlightActions_LiftOff;
    public struct FlightActionsActions
    {
        private @PlayerController m_Wrapper;
        public FlightActionsActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementControl => m_Wrapper.m_FlightActions_MovementControl;
        public InputAction @LiftOff => m_Wrapper.m_FlightActions_LiftOff;
        public InputActionMap Get() { return m_Wrapper.m_FlightActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlightActionsActions set) { return set.Get(); }
        public void SetCallbacks(IFlightActionsActions instance)
        {
            if (m_Wrapper.m_FlightActionsActionsCallbackInterface != null)
            {
                @MovementControl.started -= m_Wrapper.m_FlightActionsActionsCallbackInterface.OnMovementControl;
                @MovementControl.performed -= m_Wrapper.m_FlightActionsActionsCallbackInterface.OnMovementControl;
                @MovementControl.canceled -= m_Wrapper.m_FlightActionsActionsCallbackInterface.OnMovementControl;
                @LiftOff.started -= m_Wrapper.m_FlightActionsActionsCallbackInterface.OnLiftOff;
                @LiftOff.performed -= m_Wrapper.m_FlightActionsActionsCallbackInterface.OnLiftOff;
                @LiftOff.canceled -= m_Wrapper.m_FlightActionsActionsCallbackInterface.OnLiftOff;
            }
            m_Wrapper.m_FlightActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementControl.started += instance.OnMovementControl;
                @MovementControl.performed += instance.OnMovementControl;
                @MovementControl.canceled += instance.OnMovementControl;
                @LiftOff.started += instance.OnLiftOff;
                @LiftOff.performed += instance.OnLiftOff;
                @LiftOff.canceled += instance.OnLiftOff;
            }
        }
    }
    public FlightActionsActions @FlightActions => new FlightActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IFlightActionsActions
    {
        void OnMovementControl(InputAction.CallbackContext context);
        void OnLiftOff(InputAction.CallbackContext context);
    }
}
