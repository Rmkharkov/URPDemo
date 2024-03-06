using UnityEngine;

namespace Input
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "Configs/InputConfig", order = 0)]
    public class InputConfig : ScriptableObject
    {
        private static InputConfig _instance;

        public static InputConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<InputConfig>("InputConfig");
                }
                return _instance;
            }
        }

        [SerializeField] private float minimumInputForReaction;
        public float MinimumInputForReaction => minimumInputForReaction;
    }
}