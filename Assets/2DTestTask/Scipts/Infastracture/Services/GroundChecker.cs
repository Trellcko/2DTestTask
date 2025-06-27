using Constants;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public class GroundCheckService : IGroundCheckService
    {
        private readonly Collider2D[] _collider = new Collider2D[1];
        
        public bool CheckForGround(Vector2 position, float radius)
        {
            return Physics2D.OverlapCircleNonAlloc(position, radius, _collider, LayerNames.GroundLayer) > 0;
        }
    }
}
