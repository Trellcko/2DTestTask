using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface IOverlapCheckService
    {
        bool CheckForGround(Vector2 position, float radius, LayerMask layerMask);
    }
}