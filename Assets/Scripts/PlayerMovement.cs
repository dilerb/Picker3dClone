using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private enum Situation
    {
        Stable,
        Moving
    }

    [SerializeField] private Situation situation;
    [SerializeField] private float speed;
    [SerializeField] private float forceSpeed;
    private Vector3 clickPosition;
    private Rigidbody rb;

    void Start()
    {
        situation = Situation.Stable;
        rb = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (situation == Situation.Moving)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector3.right * forceSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector3.left * forceSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }

    public void ChangeSituation()
    {
        if (situation == Situation.Stable)
        {
            situation = Situation.Moving;
        }
        else
        {
            situation = Situation.Stable;
        }
    }
}
