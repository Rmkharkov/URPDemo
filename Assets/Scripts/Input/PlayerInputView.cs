using System;
using Misc;
using UniRx;
using UnityEngine;

namespace Input
{
    public class PlayerInputView : BaseView<PlayerInputModel, PlayerInputController>, IPlayerInput
    {
        public FloatReactiveProperty Forward { get; private set; } = new FloatReactiveProperty();
        public FloatReactiveProperty Backward { get; private set; } = new FloatReactiveProperty();
        public FloatReactiveProperty StrafeLeft { get; private set; } = new FloatReactiveProperty();
        public FloatReactiveProperty StrafeRight { get; private set; } = new FloatReactiveProperty();
        public ReactiveCommand Stop { get; private set; } = new ReactiveCommand();


        private Vector2 _lastInput;
        
        private InputConfig UsedInputConfig => InputConfig.Instance;

        private void Start()
        {
            Model.Stick.PositionUpdate.Subscribe(OnStickMove).AddTo(this);
            Model.Stick.OnRelease.Subscribe(_ => OnRelease()).AddTo(this);
        }

        private void OnStickMove(Vector2 input)
        {
            _lastInput = input;
        }

        private void Update()
        {
            if (_lastInput.x > UsedInputConfig.MinimumInputForReaction)
            {
                StrafeRight.SetValueAndForceNotify(_lastInput.x);
            }
            else if (_lastInput.x < -UsedInputConfig.MinimumInputForReaction)
            {
                StrafeLeft.SetValueAndForceNotify(_lastInput.x);
            }
            
            if (_lastInput.y > UsedInputConfig.MinimumInputForReaction)
            {
                Forward.SetValueAndForceNotify(_lastInput.y);
            }
            else if (_lastInput.y < -UsedInputConfig.MinimumInputForReaction)
            {
                Backward.SetValueAndForceNotify(_lastInput.y);
            }
        }

        private void OnRelease()
        {
            _lastInput = Vector2.zero;
            Stop.Execute();
        }
    }
}