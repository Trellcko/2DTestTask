using Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Saving;
using Trell.TwoDTestTask.Infrastructure.States;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.States
{
    public class LoadProgressState : BaseStateWithoutPayload
    {
       

        public LoadProgressState(StateMachine machine, ISaveService saveService, IPersistantPlayerProgressService persistantPlayerProgress) : base(machine)
        {
           
        }

        public override void Enter()
        {
        }

        private static SaveData InitNew() => 
            new()
            {
            };
    }
}