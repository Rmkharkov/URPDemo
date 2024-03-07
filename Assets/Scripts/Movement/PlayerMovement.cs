using Input;
using UniRx;
using UnityEngine;
using Zenject;

namespace Movement
{
    public class PlayerMovement : BaseMovementView, IPlayerMovement
    {
        public Vector3 Velocity => Model.Body.velocity;
        
        private IPlayerInput _playerInput;

        [Inject]
        private void Construct(IPlayerInput input)
        {
            _playerInput = input;
        }

        private void Start()
        {
            _playerInput.StrafeLeft.Subscribe(Controller.StrafeLeft).AddTo(this);
            _playerInput.StrafeRight.Subscribe(Controller.StrafeRight).AddTo(this);
            _playerInput.Forward.Subscribe(Controller.Forward).AddTo(this);
            _playerInput.Backward.Subscribe(Controller.Backward).AddTo(this);
            _playerInput.Stop.Subscribe(_ => Controller.Stop()).AddTo(this);
        }
    }
}