using UnityEngine;

namespace Pong.BallBehavior
{
    public class BallDeathInfo : MonoBehaviour
    {
        [SerializeField] private bool damagesLeftPlayer;

        public bool DamageLeftPlayer => damagesLeftPlayer;
    }
}