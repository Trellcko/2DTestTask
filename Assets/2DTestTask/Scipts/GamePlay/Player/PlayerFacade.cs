using UnityEngine;

namespace Trell.TwoDTestTask.Gameplay.Player
{
    public class PlayerFacade : MonoBehaviour
    {
        [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
        [field: SerializeField] public PlayerShooting PlayerShooting { get; private set; }
    }
}
