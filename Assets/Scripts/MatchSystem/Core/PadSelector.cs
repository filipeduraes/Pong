using System;
using Pong.Pad;
using UnityEngine;

namespace Pong.MatchSystem
{
    public class PadSelector : MonoBehaviour
    {
        [SerializeField] private PadMovement leftPad;
        [SerializeField] private PadMovement rightPad;
        [SerializeField] private PadControllerType leftPadControllerType;
        [SerializeField] private PadControllerType rightPadControllerType;

        private void Awake()
        {
            ChangePadController(leftPadControllerType, rightPadControllerType);
        }

        public void ChangePadController(PadControllerType leftPadControllerType, PadControllerType rightPadControllerType)
        {
            ChangePadController(true, leftPadControllerType);
            ChangePadController(false, rightPadControllerType);
        }

        private void ChangePadController(bool isLeftPad, PadControllerType padControllerType)
        {
            PadMovement padToChange = GetPadMovement(isLeftPad);
            IPadController padController;
            
            switch (padControllerType)
            {
                case PadControllerType.PlayerController:
                    padController = padToChange.gameObject.AddComponent<PlayerController>();
                    break;
                case PadControllerType.AIController:
                    padController = padToChange.gameObject.AddComponent<AIController>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(padControllerType), padControllerType, null);
            }
            
            padController.Possess(padToChange, isLeftPad);
        }

        private PadMovement GetPadMovement(bool isLeftPad)
        {
            return isLeftPad ? leftPad : rightPad;
        }
    }
    
    public enum PadControllerType
    {
        PlayerController,
        AIController
    }
}
