using UnityEngine;
using TMPro;

namespace Runner
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] GameObject UI;
        [SerializeField] TextMeshProUGUI _scoreView, _maxScoreView;
        [SerializeField] Score _score;

        public void Show()
        {
            UI.SetActive(true);
            _scoreView.text = _score.Get().ToString();
            _maxScoreView.text = _score.GetMax().ToString();
        }

        public void Hide()
        {
            UI.SetActive(false);
        }
    }

}
