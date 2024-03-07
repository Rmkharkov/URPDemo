using TMPro;
using UnityEngine;

namespace Misc
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private float frequency;
        private TextMeshProUGUI _textMesh;
        private float _timer;
        private int _frameCount;

        void Start()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        void LateUpdate()
        {
            _timer += Time.deltaTime;
            _frameCount++;
            if (_timer >= frequency)
            {
                _timer = 0;
                _textMesh.text = Mathf.RoundToInt(_frameCount / frequency) + "";
                _frameCount = 0;
            }
        }
    }
}