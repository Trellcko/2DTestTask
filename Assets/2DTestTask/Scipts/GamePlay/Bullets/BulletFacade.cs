using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Bullet
{
    public class BulletFacade : MonoBehaviour
    {
        [field: SerializeField] public BulletMovement BulletMovement { get; private set; }
    }
}
