using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace C2M2.Utils
{

    public class QuitGame : MonoBehaviour
    {
        public KeyCode quitKey = KeyCode.Escape;
        //public OVRInput.Button quitButton = OVRInput.Button.Start;
        public VRInputButtons.Button quitButtonXR;
        VRInputManager device = new VRInputManager();
        //[SerializeField]
        //public UnityEngine.XR.InputFeatureUsage<bool> quickButton = CommonUsages.menuButton;
        //public UnityEngine.XR.InputDevice device; //Find which controller this device belongs to.
        //Abstract this class into a controls manager that gives access to the buttons.
        //Use unity NEW Input manager module.
        //Replace emulator with XR simulator.
        private bool OculusRequested
        {
            get
            {
                //Any class in C2M2 with OVRINPUT.Get
                //
                //XR.CommonUsages.grip.
                //XR.CommonUsages.primaryTouch.
                /*
                bool triggerValue;
                if (device.TryGetFeatureValue(quickButton, out triggerValue) && triggerValue)
                {
                    Debug.Log("Trigger button is pressed.");
                }
                */

                //return OVRInput.Get(quitButton, OVRInput.Controller.LTouch) || OVRInput.Get(quitButton, OVRInput.Controller.RTouch);
                return device.Get((int)quitButtonXR, 0) || device.Get((int)quitButtonXR, 1);
            }
        }
        private bool QuitRequested
        {
            get
            {
                return OculusRequested;
                /*
                return GameManager.instance.VrIsActive ?
                    (OculusRequested || Input.GetKey(quitKey))
                    : Input.GetKey(quitKey); //
                */
            }
        }

        [Tooltip("If true, game will quit after X frames.")]
        public bool QuitAfterX = false;
        [Tooltip("Number of frames to quit after.")]
        public int xFrames = 300;

        // Update is called once per frame
        void Update()
        {
            // Quit if the user requests or when the user requests
            if ((QuitAfterX && Time.frameCount >= xFrames) || QuitRequested)
            {
                Debug.Log("Quit game");
                Quit();
            }
        }

        private void Quit()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}