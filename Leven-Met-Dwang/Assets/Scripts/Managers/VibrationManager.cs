using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.OpenXR.Input;

public class VibrationManager : MonoBehaviour
{
    [SerializeField] InputActionReference leftHapticAction;
    [SerializeField] InputActionReference rightHapticAction;

    private static VibrationManager _instance;

    public static VibrationManager Instance
    {
        get
        {
            // If there is no instance yet, find or create one
            if (_instance == null)
            {
                _instance = FindObjectOfType<VibrationManager>();

                // If there are no instances in the scene, create a new one
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(VibrationManager).Name);
                    _instance = singletonObject.AddComponent<VibrationManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure there's only one instance
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the instance to this object
        _instance = this;

        // Make sure it persists between scenes
        DontDestroyOnLoad(this.gameObject);
    }

    public void VibrateLeftController(float amplitude = 0.5f, float duration = 1f)
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();

        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.LeftHanded, devices);
        foreach (var device in devices)
        {
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }

    public void VibrateRightController(float amplitude = 0.5f, float duration = 1f)
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();

        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.RightHanded, devices);
        foreach (var device in devices)
        {
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }
}
