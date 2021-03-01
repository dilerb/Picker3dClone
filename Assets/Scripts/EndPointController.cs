using UnityEngine;
using DG.Tweening;

public class EndPointController : MonoBehaviour
{
    [SerializeField] private float forceSpeed;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "CarriedObjects")
        {
            collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
