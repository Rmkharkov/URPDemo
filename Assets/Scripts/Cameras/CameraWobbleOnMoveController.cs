using Input;
using Movement;
using UniRx;
using UnityEngine;

namespace Cameras
{
    public class CameraWobbleOnMoveController : BaseController<CameraWobbleOnMoveModel>
    {
        private MovementConfig UsedMovementConfig => MovementConfig.Instance;
        
        private bool _isOnMoveInput;
        private bool _isWobbleActive;
        private float _animatorStartSpeed;
        
        private BoolReactiveProperty MoveStateChanged { get; } = new BoolReactiveProperty(false);

        public void Init(IPlayerInput playerInput, GameObject disposableObject)
        {
            MoveStateChanged.Subscribe(OnMoveStateChanged).AddTo(disposableObject);
            playerInput.Backward.Subscribe(OnMoveInput).AddTo(disposableObject);
            playerInput.Forward.Subscribe(OnMoveInput).AddTo(disposableObject);
            playerInput.StrafeLeft.Subscribe(OnMoveInput).AddTo(disposableObject);
            playerInput.StrafeRight.Subscribe(OnMoveInput).AddTo(disposableObject);
            playerInput.Stop.Subscribe(_ => OnMoveInputRelease()).AddTo(disposableObject);

            _animatorStartSpeed = Model.CameraAnimator.speed;
            Model.CameraAnimator.speed = 0f;
        }
        
        public void CheckMoveConditions()
        {
            if ((Mathf.Abs(Model.TrackBody.velocity.x) > UsedMovementConfig.MinimumDistanceToWobbleCamera ||
                 Mathf.Abs(Model.TrackBody.velocity.z) > UsedMovementConfig.MinimumDistanceToWobbleCamera) && 
                _isOnMoveInput)
            {
                MoveStateChanged.SetValueAndForceNotify(true);
            }
            else
            {
                MoveStateChanged.SetValueAndForceNotify(false);
            }
        }

        private void OnMoveStateChanged(bool on)
        {
            if (_isWobbleActive != on)
            {
                _isWobbleActive = on;
                Model.CameraAnimator.speed = _isWobbleActive ? _animatorStartSpeed : 0f;
            }
        }

        private void OnMoveInput(float factor)
        {
            if (factor != 0)
            {
                OnMoveInputStart();
            }
        }

        private void OnMoveInputStart()
        {
            _isOnMoveInput = true;
        }

        private void OnMoveInputRelease()
        {
            _isOnMoveInput = false;
        }
    }
}