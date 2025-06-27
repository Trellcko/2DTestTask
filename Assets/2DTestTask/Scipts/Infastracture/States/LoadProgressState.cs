using Trell.TwoDTestTask.Infrastructure.Saving;

namespace Trell.TwoDTestTask.Infrastructure.States
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