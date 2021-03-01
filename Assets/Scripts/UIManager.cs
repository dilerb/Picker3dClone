using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject replayPanel;
    [SerializeField] private GameObject nextLevelPanel;

    public void openReplayPanel()
    {
        replayPanel.SetActive(true);
    }
    public void openNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
    }
}
