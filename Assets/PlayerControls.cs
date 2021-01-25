// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gouvernail"",
            ""id"": ""fc0dbcd0-356d-40c2-ad5d-4c78d45f006c"",
            ""actions"": [
                {
                    ""name"": ""RotateBarre"",
                    ""type"": ""Value"",
                    ""id"": ""3dac67e7-0c1e-4b30-985e-6d1f07cb3506"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Message"",
                    ""type"": ""Button"",
                    ""id"": ""96920c10-ab0b-4c2b-ae74-1a80a9d1433a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""08adf0fc-e22a-4d2c-b69e-a747e7527724"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarre"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2c904858-63c7-477d-b8f4-52d5a606d32e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarre"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6559a64e-b7b4-4a3d-96b4-426f309e76d5"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarre"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""05481cc2-a0e2-45f0-abbf-8adbdb7d726d"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarre"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""adf120e5-f404-4631-9bf6-b4b3286e607b"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarre"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3ed476be-b3f7-4782-986d-ff6076c428f2"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBarre"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""55f10557-5514-47a8-a233-5dd64e390214"",
                    ""path"": ""<SwitchProControllerHID>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Message"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4071bb9-21c9-4b29-b10c-3c74feede4dd"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Message"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""0a1462b5-bdc9-4ac9-9f33-962379d9b166"",
            ""actions"": [
                {
                    ""name"": ""Voile_Gauche"",
                    ""type"": ""Button"",
                    ""id"": ""47a46edd-578e-4360-8548-72249cae29ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Voile_Droite"",
                    ""type"": ""Button"",
                    ""id"": ""d0b76973-a486-47d4-b9c4-b71d99f199ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gouvernail_Gauche"",
                    ""type"": ""Button"",
                    ""id"": ""4480e11a-b09c-4da9-b3e5-2900625f4349"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Gouvernail_Droite"",
                    ""type"": ""Button"",
                    ""id"": ""d343bb88-8296-4e43-919b-d61ea1ef506d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a95af0a-4a53-4c34-a539-117ec52389f6"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Voile_Gauche"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b6abea7-345b-476c-a0df-265589326799"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Voile_Droite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5bee9f0-fae7-42f8-91af-ebfaeebad82b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gouvernail_Gauche"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60918fb9-fe2b-4302-9b03-52e26ffcaae0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gouvernail_Droite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gouvernail
        m_Gouvernail = asset.FindActionMap("Gouvernail", throwIfNotFound: true);
        m_Gouvernail_RotateBarre = m_Gouvernail.FindAction("RotateBarre", throwIfNotFound: true);
        m_Gouvernail_Message = m_Gouvernail.FindAction("Message", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Voile_Gauche = m_Debug.FindAction("Voile_Gauche", throwIfNotFound: true);
        m_Debug_Voile_Droite = m_Debug.FindAction("Voile_Droite", throwIfNotFound: true);
        m_Debug_Gouvernail_Gauche = m_Debug.FindAction("Gouvernail_Gauche", throwIfNotFound: true);
        m_Debug_Gouvernail_Droite = m_Debug.FindAction("Gouvernail_Droite", throwIfNotFound: true);
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

    // Gouvernail
    private readonly InputActionMap m_Gouvernail;
    private IGouvernailActions m_GouvernailActionsCallbackInterface;
    private readonly InputAction m_Gouvernail_RotateBarre;
    private readonly InputAction m_Gouvernail_Message;
    public struct GouvernailActions
    {
        private @PlayerControls m_Wrapper;
        public GouvernailActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateBarre => m_Wrapper.m_Gouvernail_RotateBarre;
        public InputAction @Message => m_Wrapper.m_Gouvernail_Message;
        public InputActionMap Get() { return m_Wrapper.m_Gouvernail; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GouvernailActions set) { return set.Get(); }
        public void SetCallbacks(IGouvernailActions instance)
        {
            if (m_Wrapper.m_GouvernailActionsCallbackInterface != null)
            {
                @RotateBarre.started -= m_Wrapper.m_GouvernailActionsCallbackInterface.OnRotateBarre;
                @RotateBarre.performed -= m_Wrapper.m_GouvernailActionsCallbackInterface.OnRotateBarre;
                @RotateBarre.canceled -= m_Wrapper.m_GouvernailActionsCallbackInterface.OnRotateBarre;
                @Message.started -= m_Wrapper.m_GouvernailActionsCallbackInterface.OnMessage;
                @Message.performed -= m_Wrapper.m_GouvernailActionsCallbackInterface.OnMessage;
                @Message.canceled -= m_Wrapper.m_GouvernailActionsCallbackInterface.OnMessage;
            }
            m_Wrapper.m_GouvernailActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotateBarre.started += instance.OnRotateBarre;
                @RotateBarre.performed += instance.OnRotateBarre;
                @RotateBarre.canceled += instance.OnRotateBarre;
                @Message.started += instance.OnMessage;
                @Message.performed += instance.OnMessage;
                @Message.canceled += instance.OnMessage;
            }
        }
    }
    public GouvernailActions @Gouvernail => new GouvernailActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Voile_Gauche;
    private readonly InputAction m_Debug_Voile_Droite;
    private readonly InputAction m_Debug_Gouvernail_Gauche;
    private readonly InputAction m_Debug_Gouvernail_Droite;
    public struct DebugActions
    {
        private @PlayerControls m_Wrapper;
        public DebugActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Voile_Gauche => m_Wrapper.m_Debug_Voile_Gauche;
        public InputAction @Voile_Droite => m_Wrapper.m_Debug_Voile_Droite;
        public InputAction @Gouvernail_Gauche => m_Wrapper.m_Debug_Gouvernail_Gauche;
        public InputAction @Gouvernail_Droite => m_Wrapper.m_Debug_Gouvernail_Droite;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Voile_Gauche.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnVoile_Gauche;
                @Voile_Gauche.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnVoile_Gauche;
                @Voile_Gauche.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnVoile_Gauche;
                @Voile_Droite.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnVoile_Droite;
                @Voile_Droite.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnVoile_Droite;
                @Voile_Droite.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnVoile_Droite;
                @Gouvernail_Gauche.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnGouvernail_Gauche;
                @Gouvernail_Gauche.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnGouvernail_Gauche;
                @Gouvernail_Gauche.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnGouvernail_Gauche;
                @Gouvernail_Droite.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnGouvernail_Droite;
                @Gouvernail_Droite.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnGouvernail_Droite;
                @Gouvernail_Droite.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnGouvernail_Droite;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Voile_Gauche.started += instance.OnVoile_Gauche;
                @Voile_Gauche.performed += instance.OnVoile_Gauche;
                @Voile_Gauche.canceled += instance.OnVoile_Gauche;
                @Voile_Droite.started += instance.OnVoile_Droite;
                @Voile_Droite.performed += instance.OnVoile_Droite;
                @Voile_Droite.canceled += instance.OnVoile_Droite;
                @Gouvernail_Gauche.started += instance.OnGouvernail_Gauche;
                @Gouvernail_Gauche.performed += instance.OnGouvernail_Gauche;
                @Gouvernail_Gauche.canceled += instance.OnGouvernail_Gauche;
                @Gouvernail_Droite.started += instance.OnGouvernail_Droite;
                @Gouvernail_Droite.performed += instance.OnGouvernail_Droite;
                @Gouvernail_Droite.canceled += instance.OnGouvernail_Droite;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IGouvernailActions
    {
        void OnRotateBarre(InputAction.CallbackContext context);
        void OnMessage(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnVoile_Gauche(InputAction.CallbackContext context);
        void OnVoile_Droite(InputAction.CallbackContext context);
        void OnGouvernail_Gauche(InputAction.CallbackContext context);
        void OnGouvernail_Droite(InputAction.CallbackContext context);
    }
}
