using UnityEngine;

namespace Movement
{
    [System.Serializable]
    public class BaseMovementModel : BaseModel
    {
        [SerializeField] private Rigidbody body;
        public Rigidbody Body => body;
    }
}