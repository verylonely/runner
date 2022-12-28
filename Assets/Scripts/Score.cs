using System;
using UnityEngine;
using VLTools;

namespace Runner
{
    public class Score : MonoBehaviour
    {
        public static Score instance;

        public event Action OnValueChanged;

        int _score, _maxScore, _lastMaxScore;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            Load();

            _lastMaxScore = _maxScore;

            Game.instance.OnSave += Save;
        }

        public void AddScore()
        {
            _score += 1;

            if (_score > _maxScore)
                _maxScore = _score;

            OnValueChanged.Invoke();
        }

        public int Get()
        {
            return _score;
        }

        public int GetMax()
        {
            return _maxScore;
        }

        void Save()
        {
            if(_lastMaxScore < _maxScore)
                SaveLoad.Save<int>(_maxScore, "score");
        }

        void Load()
        {
            if (SaveLoad.SaveExist("score"))
                _maxScore = SaveLoad.Load<int>("score");
        }
    }
}
