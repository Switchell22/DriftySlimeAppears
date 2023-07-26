using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class TopPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text dayLabel;
        [SerializeField] private TMP_Text coinsLabel;
        [SerializeField] private TMP_Text timeLabel;
        [SerializeField] private TMP_Text hpLabel;
        [SerializeField] private TMP_Text gameOverText;

        private void Start()
        {
            Refresh();
            InvokeRepeating("Refresh", 1f, 1f);
        }

        public void Refresh()
        {
            dayLabel.text = $"Day {GameDataManager.Instance.CurrentData.day}";
            coinsLabel.text = GameDataManager.Instance.CurrentData.coins.ToString("N0");
            timeLabel.text = GameDataManager.Instance.CurrentData.timeRemaining.ToString();
            hpLabel.text = GameDataManager.Instance.CurrentData.hp.ToString();

            if (GameDataManager.Instance.CurrentData.hp <= 0)
            {
                gameOverText.fontSize = 256;
            }
        }
    }
}
