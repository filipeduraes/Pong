using Pong.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pong.Pad
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PadMovement testPad;
        [SerializeField] private bool testPadIsLeft;
        
        private PlayerInputs _playerInputs;
        private PadMovement _padMovement;
        private InputAction _moveAction;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            Posses(testPad, testPadIsLeft);
        }

        private void OnDestroy()
        {
            _playerInputs.Dispose();
            ReleasePossession();
        }

        private void OnEnable()
        {
            _playerInputs.Enable();
        }

        private void OnDisable()
        {
            _playerInputs.Disable();
        }

        public void Posses(PadMovement padMovement, bool isLeftPlayer)
        {
            _padMovement = padMovement;
            _moveAction = isLeftPlayer ? _playerInputs.LeftPlayer.Move : _playerInputs.RightPlayer.Move;
            
            _moveAction.performed += ProcessStartMovement;
            _moveAction.canceled += ProcessStopMovement;
        }

        public void ReleasePossession()
        {
            _moveAction.performed -= ProcessStartMovement;
            _moveAction.canceled -= ProcessStopMovement;
        }
        
        private void ProcessStartMovement(InputAction.CallbackContext context)
        {
            float direction = context.ReadValue<float>();
            _padMovement.StartMovement((int) Mathf.Sign(direction));
        }
        
        private void ProcessStopMovement(InputAction.CallbackContext _)
        {
            _padMovement.StopMovement();
        }
    }
}