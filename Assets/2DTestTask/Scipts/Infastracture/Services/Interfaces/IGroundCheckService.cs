using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface IGroundCheckService
    {
        bool CheckForGround(Vector2 position, float radius);
    }
}