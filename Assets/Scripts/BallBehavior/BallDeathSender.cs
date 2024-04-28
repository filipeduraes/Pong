using System;
using UnityEngine;

namespace Pong.BallBehavior
{
    public class BallDeathSender : MonoBehaviour
    {
        [SerializeField] private LayerMask hitboxLayer;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((1 << other.gameObject.layer & hitboxLayer) != 0)
            {
                Debug.Log("DEIXOU DE VIVER");
            }
        }
    }
}
