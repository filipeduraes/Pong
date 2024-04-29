using UnityEngine;

namespace Pong.Utils
{
    public static class LayerUtils
    {
        public static bool CompareLayer(this LayerMask layerMask, int layer)
        {
            return (1 << layer & layerMask) != 0;
        }
    }
}