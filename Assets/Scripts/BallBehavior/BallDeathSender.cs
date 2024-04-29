using System;
using UnityEngine;
using Pong.Utils;

namespace Pong.BallBehavior
{
    public class BallDeathSender : MonoBehaviour
    {
        [SerializeField] private LayerMask hitboxLayer;

        public event Action<bool> OnBallDeath = delegate { };
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (hitboxLayer.CompareLayer(other.gameObject.layer))
            {
                if(other.TryGetComponent(out BallDeathInfo deathInfo))
                    OnBallDeath(deathInfo.DamageLeftPlayer);
            }
        }
    }
}
