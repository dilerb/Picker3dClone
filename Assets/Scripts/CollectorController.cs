using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class CollectorController : MonoBehaviour
{
    [SerializeField] private int neededObjectCount;
    [SerializeField] private GameObject upWall;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject picker;
    [SerializeField] private GameObject UIManager;
    [SerializeField] private GameObject levelController;
    [SerializeField] private Text objectCountText;
    private int collectedObjectCount;
    private bool firstTrigger;

    private void Start()
    {
        firstTrigger = false;
        collectedObjectCount = 0;
        ChangeObjectCountText(collectedObjectCount);
    }

    void OnTriggerEnter(Collider collider)
    {
        if ((collider.tag == "Picker") && (!firstTrigger))
        {
            firstTrigger = true;
            collider.GetComponentInParent<PlayerMovement>().ChangeSituation();
            Invoke("CheckObjectCount", 3f);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "CarriedObjects")
        {
            Destroy(collider, 2.5f);
            collectedObjectCount++;
            ChangeObjectCountText(collectedObjectCount);
        }

    }

    void CheckObjectCount()
    {
        if (collectedObjectCount >= neededObjectCount)
        {
            Destroy(upWall);
            Destroy(bottomWall);

            parentObject.transform.DOLocalMoveY(0f, 3f)
                .OnComplete(() => picker.GetComponent<PlayerMovement>().ChangeSituation());

            levelController.GetComponent<LevelController>().NextStage();

            //Destroy(this);
            //change colors
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        UIManager.GetComponent<UIManager>().openReplayPanel();
    }

    private void ChangeObjectCountText(int i)
    {
        objectCountText.text = i + "/" + neededObjectCount;
    }
}
