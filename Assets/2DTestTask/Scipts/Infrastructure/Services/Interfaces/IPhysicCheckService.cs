using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface IPhysicCheckService
    {
        bool OverlapSphere(Vector2 position, float radius, params LayerMask[] layerMask);
        bool CheckForObstacleBetweenObjects(Vector2 position, Vector2 target, float maxDistance, params LayerMask[] obstacles);
    }
}