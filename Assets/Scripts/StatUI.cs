using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class StatUI : MonoBehaviour
    {
        [SerializeField] Slider _healthBar;
        [SerializeField] TextMeshProUGUI _healthValue;
        [SerializeField] Health _health;

        [SerializeField] TextMeshProUGUI _scoreView;
        [SerializeField] Score _score;


        void Start()
        {
            _health.OnValueChanged += UpdateUI;
            _score.OnValueChanged += UpdateUI;
            UpdateUI();
        }

        void UpdateUI()
        {
            _healthValue.text = $"{_health.Get()}/{_health.GetMax()}";

            float value = 100f * _health.Get() / _health.GetMax() / 100f;

            _healthBar.value = value;

            _scoreView.text = _score.Get().ToString();

        }
    }
}
