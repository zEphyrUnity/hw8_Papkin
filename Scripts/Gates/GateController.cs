using UnityEngine;


public class GateController : MonoBehaviour
{
    private Animator _GateAnimator;

    private void Start()
    {
        _GateAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            _GateAnimator.SetBool("IsGateOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            _GateAnimator.SetBool("IsGateOpen", false);
        }
    }
}