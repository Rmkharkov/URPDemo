using System;
using Input;
using Zenject;

namespace Cameras
{
    public class CameraWobbleOnMoveView : BaseView<CameraWobbleOnMoveModel, CameraWobbleOnMoveController>
    {
        private IPlayerInput _playerInput;
        
        [Inject]
        private void Construct(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        private void Start()
        {
            Controller.Init(_playerInput, gameObject);
        }

        private void Update()
        {
            Controller.CheckMoveConditions();
        }
    }
}