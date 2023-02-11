using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class GameObjectsExtentions
    {
        public static bool IsInLayer(this GameObject go, LayerMask layer)
        {
            return layer == (layer | 1 << go.layer);
        }
    }
}
