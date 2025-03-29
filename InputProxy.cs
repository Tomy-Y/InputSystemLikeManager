using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystemLikeManager
{
    public class InputProxy : MonoBehaviour
    {
        public class InputData
        {
            public bool on, down, up;
            public int count;
        }

        public Vector2 axisMove;
        public Vector2 axisLook;

        // Input Data Dictionary
        private Dictionary<string, InputData> buttonInputs = new();

        // Action Names
        private readonly string[] actionNames = new string[]
        {
           "Jump", "Change"
        };

        private void Awake()
        {
            foreach (var name in actionNames)
            {
                buttonInputs[name] = new InputData();
            }
        }

        void Update()
        {
            foreach (var data in buttonInputs.Values)
            {
                InputDataProcedure(data);
            }
        }

        private void InputDataProcedure(InputData inputData)
        {
            if (inputData.on)
            {
                inputData.down = (inputData.count == 0);
                inputData.count++;
            }
            else
            {
                if (inputData.count > 0)
                {
                    inputData.up = true;
                    inputData.count = 0;
                }
                else
                {
                    inputData.up = false;
                }
            }
        }

        public void OnMove(InputValue value)
        {
            axisMove = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            axisLook = value.Get<Vector2>();
        }

        // Button Inputs
        public void OnInput(string actionName, InputValue value)
        {
            if (buttonInputs.TryGetValue(actionName, out var inputData))
            {
                inputData.on = value.isPressed;
            }
        }

        // Wrapper Methods
        public void OnJump(InputValue value) => OnInput("Jump", value);
        public void OnChange(InputValue value) => OnInput("Change", value);
        // ’Ç‰Á‚·‚éê‡‚Íã‹L‚É•í‚Á‚Ä’Ç‰Á


        public InputData GetInput(string name) => buttonInputs.TryGetValue(name, out var data) ? data : null;
    }
}
