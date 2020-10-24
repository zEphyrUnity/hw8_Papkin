using UnityEngine;


public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private enum OpenDirection { x, y, z }
    [SerializeField] private OpenDirection direction = OpenDirection.x;
    [SerializeField] private float openDistance = 1.3f;
    [SerializeField] private float openSpeed = 2.0f;
    [SerializeField] private Transform doorBody;

    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closeDoor;
    private AudioSource _audioSource;
    private bool open = false;

    Vector3 defaultDoorPosition;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();

        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition;
        }
    }

    void Update()
    {
        if (!doorBody)
            return;

        if (direction == OpenDirection.x)
        {
            doorBody.localPosition = new Vector3(Mathf.Lerp(doorBody.localPosition.x, defaultDoorPosition.x + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.y, doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.y)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(doorBody.localPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.z)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(doorBody.localPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), Time.deltaTime * openSpeed));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            open = true;
            _audioSource.PlayOneShot(openDoor);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            open = false;
            _audioSource.PlayOneShot(closeDoor);
        }
    }
}
