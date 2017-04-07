using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D {
    [RequireComponent(typeof(PlayerShip))]
    public class PlayerInput : MonoBehaviour {
        public class Input {
            public bool prevUp;
            public bool prevDown;
            public bool prevLeft;
            public bool prevRight;

            public bool up;
            public bool down;
            public bool left;
            public bool right;

            public bool fireDown;
            public bool fireHold;
            public bool fireUp;

            public bool specialDown;
            public bool specialHold;
            public bool specialUp;

            public void reset() {
                prevUp = up;
                prevDown = down;
                prevLeft = left;
                prevRight = right;

                up = false;
                down = false;
                left = false;
                right = false;

                fireDown = false;
                fireUp = false;

                specialDown = false;
                specialUp = false;
            }
        }

        private Input input;
        private PlayerShip player;

        // Use this for initialization
        private void Awake() {
            input = new Input();
            player = GameObject.Find("PlayerShip").GetComponent<PlayerShip>();
        }

        // Update is called once per frame
        private void Update() {
            if (!input.fireDown)    { input.fireDown = CrossPlatformInputManager.GetButtonDown("Fire"); }
            if (!input.fireUp)      { input.fireDown = CrossPlatformInputManager.GetButtonUp("Fire"); }
            if (!input.specialDown) { input.fireDown = CrossPlatformInputManager.GetButtonDown("Special"); }
            if (!input.specialDown) { input.fireDown = CrossPlatformInputManager.GetButtonUp("Special"); }

            if (CrossPlatformInputManager.GetAxis("Vertical") > 0)   { input.up = true; }
            if (CrossPlatformInputManager.GetAxis("Vertical") < 0)   { input.down = true; }
            if (CrossPlatformInputManager.GetAxis("Horizontal") < 0) { input.left = true; }
            if (CrossPlatformInputManager.GetAxis("Horizontal") > 0) { input.right = true; }
        }

        private void FixedUpdate() {
            input.fireHold = CrossPlatformInputManager.GetButton("Fire");
            input.specialHold = CrossPlatformInputManager.GetButton("Special");

            player.Move(input);
            input.reset();
        }
    }

}