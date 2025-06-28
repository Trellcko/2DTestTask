using Constants;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public class PhysicCheckService : IPhysicCheckService
    {
        private readonly Collider2D[] _collider = new Collider2D[1];
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[1];
        
        public bool OverlapSphere(Vector2 position, float radius, params LayerMask[] layerMask)
        {
            return Physics2D.OverlapCircleNonAlloc(position, radius, _collider, GetLayerMask(layerMask)) > 0;
        }

        public bool CheckForObstacleBetweenObjects(Vector2 position, Vector2 target, float maxDistance, params LayerMask[] obstacles)
        {
            float distance = Vector2.Distance(position, target);
            if (distance > maxDistance)
                return true;

            int raycastNonAlloc = Physics2D.RaycastNonAlloc(position,  (target - position).normalized, _hits, distance, GetLayerMask(obstacles));
            Debug.Log(_hits[0].transform?.name);
            return raycastNonAlloc > 0;
        }

        private int GetLayerMask(LayerMask[] layerMask)
        {
            int result = layerMask[0];
            for (int i = 1; i < layerMask.Length; i++)
            {
                result |= layerMask[i].value;
            }
            return result;
        }
    }
}
