using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;
using System;

public class VRInputManager : MonoBehaviour
{

    private InputDevice device;
    [SerializeField]
    private XRNode primaryControl = XRNode.RightHand;
    [SerializeField]
    private XRNode secondaryControl = XRNode.LeftHand;
    private delegate dynamic XRButton();

    private List<InputDevice> devices = new List<InputDevice>();
    /*
    void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
    }
    */

    void GetPrimaryDevice()
    {
        InputDevices.GetDevicesAtXRNode(primaryControl, devices);
        device = devices.FirstOrDefault();
    }

    void GetSecondaryDevice()
    {
        InputDevices.GetDevicesAtXRNode(secondaryControl, devices);
        device = devices.FirstOrDefault();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!device.isValid)
        {
            GetDevice();
        }
        bool buttonPressed;
        if(device.TryGetFeatureValue(CommonUsages.triggerButton, out buttonPressed) && buttonPressed)
        {
            Debug.Log("Pressed Trigger Button");
        }
        */
    }

    public dynamic Get(int button, int deviceController)
    {
        if (deviceController == 0)
            GetPrimaryDevice();
        else
            GetSecondaryDevice();

        XRButton xrbutton = GetFunction(button);

        return xrbutton();
    }

    XRButton GetFunction(int button)
    {
        switch (button)
        {
            case 0:
                return triggerButton;
                break;
            case 1:
                return gripButton;
                break;
            case 2:
                return menuButton;
                break;
            case 3:
                return primaryButton;
                break;
            case 4:
                return secondaryButton;
                break;
            case 5:
                return primary2DAxis;
                break;
            case 6:
                return secondary2DAxis;
                break;
            case 7:
                return trigger;
                break;
            case 8:
                return grip;
                break;

        }
        return null;
    }

    private dynamic primary2DAxis()
    {
        Vector2 value;
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out value);
        return value;
    }

    private dynamic secondary2DAxis()
    {
        Vector2 value;
        device.TryGetFeatureValue(CommonUsages.secondary2DAxis, out value);
        return value;
    }

    private dynamic trigger()
    {
        float value;
        device.TryGetFeatureValue(CommonUsages.trigger, out value);
        return value;
    }

    private dynamic grip()
    {
        float value;
        device.TryGetFeatureValue(CommonUsages.grip, out value);
        return value;
    }

    private dynamic triggerButton()
    {
        bool buttonPressed;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out buttonPressed) && buttonPressed)
        {
            buttonPressed = true;
        }
        return buttonPressed;
    }

    private dynamic gripButton()
    {
        bool buttonPressed;
        if (device.TryGetFeatureValue(CommonUsages.gripButton, out buttonPressed) && buttonPressed)
        {
            buttonPressed = true;
        }
        return buttonPressed;
    }

    private dynamic menuButton()
    {
        bool buttonPressed;
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out buttonPressed) && buttonPressed)
        {
            buttonPressed = true;
        }
        return buttonPressed;
    }

    private dynamic primaryButton()
    {
        bool buttonPressed;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPressed) && buttonPressed)
        {
            buttonPressed = true;
        }
        return buttonPressed;
    }

    private dynamic secondaryButton()
    {
        bool buttonPressed;
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out buttonPressed) && buttonPressed)
        {
            buttonPressed = true;
        }
        return buttonPressed;
    }
}
