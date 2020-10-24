using UnityEngine;


public class KalitkaController : MonoBehaviour
{
    private Animator _kalitkaAnimator;

    private void Start()
    {
        _kalitkaAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
            _kalitkaAnimator.SetBool("IsKalitkaOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
            _kalitkaAnimator.SetBool("IsKalitkaOpen", false);
    }
}
