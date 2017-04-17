using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D {
    public class PlayerInput : MonoBehaviour {
        public class Input {
            public float horizontal;
            public float vertical;

            public bool fireDown;
            public bool fireHold;
            public bool fireUp;

            public bool specialDown;
            public bool specialHold;
            public bool specialUp;

            public bool afterburnerDown;
            public bool afterburnerHold;
            public bool afterburnerUp;

            public void reset() {
                fireDown = false;
                fireUp = false;

                specialDown = false;
                specialUp = false;

                afterburnerDown = false;
                afterburnerUp = false;
            }
        }

        private Input input;
        public Ship player;
        public Camera camera;

        // Use this for initialization
        private void Awake() {
            input = new Input();
            player = gameObject.GetComponent<Ship>();
        }

        // Update is called once per frame
        private void Update() {
            if (!input.fireDown)        { input.fireDown = CrossPlatformInputManager.GetButtonDown("Fire"); }
            if (!input.fireUp)          { input.fireUp = CrossPlatformInputManager.GetButtonUp("Fire"); }
            if (!input.specialDown)     { input.specialDown = CrossPlatformInputManager.GetButtonDown("Special"); }
            if (!input.specialUp)       { input.specialUp = CrossPlatformInputManager.GetButtonUp("Special"); }
            if (!input.afterburnerDown) { input.afterburnerDown = CrossPlatformInputManager.GetButtonDown("Afterburner"); }
            if (!input.afterburnerUp)   { input.afterburnerUp = CrossPlatformInputManager.GetButtonUp("Afterburner"); }
        }

        private void FixedUpdate() {
            input.fireHold = CrossPlatformInputManager.GetButton("Fire");
            input.specialHold = CrossPlatformInputManager.GetButton("Special");
            input.afterburnerHold = CrossPlatformInputManager.GetButton("Afterburner");
            input.horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            input.vertical = CrossPlatformInputManager.GetAxis("Vertical");

            if (player) {
                player.move(input);
                player.clampToCameraBound(camera);
            }
            input.reset();
        }
    }
}