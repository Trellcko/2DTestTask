using System.Threading.Tasks;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Factories
{
    public interface IPopupFactory : IFactory
    {
        Task<GameObject> GetPopup(PopupType popupType);
    }
}