using UnityEngine;

namespace Movement
{
    [CreateAssetMenu(fileName = "MovementConfig", menuName = "Configs/MovementConfig", order = 0)]
    public class MovementConfig : ScriptableObject
    {
        private static MovementConfig _instance;

        public static MovementConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<MovementConfig>("MovementConfig");
                }
                return _instance;
            }
        }

        [SerializeField] private Vector2 moveForces;
        [SerializeField] private float maximumSpeed;
        [SerializeField] private float minimumDistanceToWobbleCamera;
        public Vector2 MoveForces => moveForces;
        public float MaximumSpeed => maximumSpeed;
        public float MinimumDistanceToWobbleCamera => minimumDistanceToWobbleCamera;
    }
}