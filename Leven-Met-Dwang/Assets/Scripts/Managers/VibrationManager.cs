using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class VibrationManager : MonoBehaviour
{
    [SerializeField] InputActionReference leftHapticAction; // Reference to the left controller haptic action
    [SerializeField] InputActionReference rightHapticAction; // Reference to the right controller haptic action

    private static VibrationManager _instance; // Singleton instance of the VibrationManager

    // Singleton pattern to ensure only one instance exists throughout the game
    public static VibrationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VibrationManager>(); // Find an existing instance

                if (_instance == null)
                {
                    // If no instance found, create a new GameObject with VibrationManager component
                    GameObject singletonObject = new GameObject(typeof(VibrationManager).Name);
                    _instance = singletonObject.AddComponent<VibrationManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure only one instance exists, destroy duplicates
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this; // Set this instance as the singleton
        DontDestroyOnLoad(this.gameObject); // Make it persist across scenes
    }

    // Method to trigger left controller vibration
    public void VibrateLeftController(float amplitude = 0.5f, float duration = 1f)
    {
        // Get devices with the role of left-handed controllers
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.LeftHanded, devices);

        // Iterate through left-handed devices and trigger haptic vibration
        foreach (var device in devices)
        {
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities) && capabilities.supportsImpulse)
            {
                uint channel = 0;
                device.SendHapticImpulse(channel, amplitude, duration);
            }
        }
    }

    // Method to trigger right controller vibration
    public void VibrateRightController(float amplitude = 0.5f, float duration = 1f)
    {
        // Get devices with the role of right-handed controllers
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithRole(UnityEngine.XR.InputDeviceRole.RightHanded, devices);

        // Iterate through right-handed devices and trigger haptic vibration
        foreach (var device in devices)
        {
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities) && capabilities.supportsImpulse)
            {
                uint channel = 0;
                device.SendHapticImpulse(channel, amplitude, duration);
            }
        }
    }
}
