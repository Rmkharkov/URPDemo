using UnityEngine;

namespace Sounds
{
    [System.Serializable]
    public class PlayerSoundModel : BaseModel
    {
        [SerializeField] private AudioSource collisionSoundSource;
        [SerializeField] private float minimalPause;
        public AudioSource CollisionSoundSource => collisionSoundSource;
        public float MinimalPause => minimalPause;
    }
}