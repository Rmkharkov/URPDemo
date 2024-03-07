using Movement;
using UnityEngine;

namespace Sounds
{
    public class PlayerSoundController : BaseController<PlayerSoundModel>
    {
        private IPlayerMovement _playerMovement;
        private MovementConfig UsedMoveConfig => MovementConfig.Instance;
        private float _lastTimePlayed;
        
        public void Init(IPlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Environment")) return;
            
            if ((Mathf.Abs(_playerMovement.Velocity.x) > UsedMoveConfig.MinimumSpeedToSoundOnCollision ||
                Mathf.Abs(_playerMovement.Velocity.y) > UsedMoveConfig.MinimumSpeedToSoundOnCollision) &&
                CanPlayNextTime)
            {
                _lastTimePlayed = Time.time;
                Model.CollisionSoundSource.Play();
            }
        }

        private bool CanPlayNextTime
        {
            get
            {
                var timeGood = _lastTimePlayed + Model.MinimalPause < Time.time;
                return !Model.CollisionSoundSource.isPlaying && timeGood;
            }
        } 
    }
}