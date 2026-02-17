using UnityEngine;
using TMPro;
using System;

namespace GameConstant // [ ] I gave the name correct?
{
    public class GameView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI waveCountdownText;

        private WaveSpawner _waveSpawner;

        public void Initialize(WaveSpawner waveSpawner)
        {
            _waveSpawner = waveSpawner;
            _waveSpawner.OnCountdown += UpdateWaveCountDown;
        }

        private void OnDestroy()
        {
            _waveSpawner.OnCountdown -= UpdateWaveCountDown;
        }

        private void UpdateWaveCountDown(float countdown)
        {
            waveCountdownText.text = "New wave in: " + Mathf.Round(countdown).ToString();
        }
    }
}
