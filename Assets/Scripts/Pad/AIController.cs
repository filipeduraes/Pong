using UnityEngine;

namespace Pong.Pad
{
    public class AIController : MonoBehaviour, IPadController
    {
        private PadMovement _padMovement;

        public void Possess(PadMovement padMovement, bool isLeftPlayer)
        {
            _padMovement = padMovement;

        }
    }
}