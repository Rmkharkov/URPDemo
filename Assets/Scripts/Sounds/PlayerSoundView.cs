using System;
using Movement;
using UnityEngine;
using Zenject;

namespace Sounds
{
    public class PlayerSoundView : BaseView<PlayerSoundModel, PlayerSoundController>
    {
        private IPlayerMovement _playerMovement;
        [Inject]
        private void Construct(IPlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        private void Start()
        {
            Controller.Init(_playerMovement);
        }

        private void OnCollisionEnter(Collision other) => Controller.OnCollisionEnter(other);
    }
}