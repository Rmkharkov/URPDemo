using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputView playerInputView;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().FromInstance(playerInputView).AsSingle();
        }
    }
}