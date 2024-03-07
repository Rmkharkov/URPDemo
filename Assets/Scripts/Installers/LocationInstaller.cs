using Input;
using Movement;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputView playerInputView;
        [SerializeField] private PlayerMovement playerMovement;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().FromInstance(playerInputView).AsSingle();
            Container.Bind<IPlayerMovement>().FromInstance(playerMovement).AsSingle();
        }
    }
}