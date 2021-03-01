using UnityEngine;
using DG.Tweening;

public class CollectibleMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] movementPaths;
    [SerializeField] private float movementSpeed;
    private Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalPath(movementPaths, movementSpeed).SetEase(Ease.Linear));
        sequence.SetLoops(-1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Picker")
        {
            //add score
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        sequence.Kill();
    }
}
