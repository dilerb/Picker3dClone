using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject UIManager;
    [SerializeField] private GameObject Picker;
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image stageImage1, stageImage2, stageImage3;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color passedColor;
    public int level;
    public int stage;

    void Start()
    {
        level = PlayerPrefs.GetInt("Level");

        if (level == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            level = 1;
        }

        stage = 0;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();

        stageImage1.color = Color.white;
        stageImage2.color = Color.white;
        stageImage3.color = Color.white;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", level + 1);
        DOTween.Clear(true);

        if (level > 9)
        {
            // get next level in random order
            SceneManager.LoadScene(Random.Range(0,10));
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void NextStage()
    {
        if (stage == 0)
        {
            stageImage1.DOColor(new Color(passedColor.r, passedColor.g, passedColor.b), 3f);
        }
        else if (stage == 1)
        {
            stageImage2.DOColor(new Color(passedColor.r, passedColor.g, passedColor.b), 3f);
        }
        else if (stage == 2) 
        {
            stageImage3.DOColor(new Color(passedColor.r, passedColor.g, passedColor.b), 3f);
            Invoke("StopPlayer", 3f);
            UIManager.GetComponent<UIManager>().openNextLevelPanel();
        }

        stage += 1;
    }
    
    private void StopPlayer()
    {
        Picker.GetComponent<PlayerMovement>().ChangeSituation();
    }
}
