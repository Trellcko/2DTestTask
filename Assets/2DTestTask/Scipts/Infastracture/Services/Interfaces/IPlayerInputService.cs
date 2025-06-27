using System;

namespace Trell.TwoDTestTask.Infrastructure.Service
{
    public interface IPlayerInputService
    {
        event Action<int> MovementButtonPressed;
        event Action MovementButtonReleased; 
        event Action JumpButtonClicked;
        event Action FireButtonClicked;
    }
}