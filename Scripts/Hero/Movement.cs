using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 130f;
    [SerializeField] private float JumpForce = 175f;
    //[SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _startBullet;
    [SerializeField] private Transform _startBomb;

    [SerializeField] private AudioClip shot;
    [SerializeField] private AudioClip reload;
    [SerializeField] private AudioClip throwBomb;

    private Rigidbody _rb;
    private Animator _heroAnimator;
    private AudioSource _audioSource;

    public static Vector3 movement;
    public static bool walking = false;

    private bool _isReloading = false;
    private bool _isReloadingBomb = false;
    private bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _heroAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();

        if (Input.GetButtonDown("Fire2"))
            PlantBomb();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal > 0.3 | moveHorizontal < -0.3 | moveVertical > 0.3 | moveVertical < -0.3)
            MovementLogic();

        JumpLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.rotation = Quaternion.LookRotation(movement);
        _rb.AddForce(movement * Speed);

        if(moveHorizontal > 0.4 | moveHorizontal < -0.4 | moveVertical > 0.4 | moveVertical < -0.4)
        {
            _heroAnimator.SetBool("StartWalking", true);
            walking = true;
        }
        else
        {
            _heroAnimator.SetBool("StartWalking", false);
            walking = false;
        }
    }

    private void Fire()
    {
        if (!_isReloading)
        {
            _audioSource.PlayOneShot(shot, _audioSource.volume) ;
            Instantiate(_bullet, _startBullet.position, _startBullet.rotation);
            _isReloading = true;
            StartCoroutine(Reloading(shot.length));
        }
    }

    private void PlantBomb()
    {
        if (!_isReloadingBomb)
        {
            _audioSource.PlayOneShot(throwBomb, _audioSource.volume);
            Instantiate(_bomb, _startBomb.position, _startBomb.rotation);
            _isReloadingBomb = true;
            Invoke("ReloadBomb", 3);
        }
    }

    IEnumerator Reloading(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.PlayOneShot(reload, _audioSource.volume);

        yield return new WaitForSeconds(reload.length);
        _isReloading = false;
    }

    private void ReloadBomb()
    {
        _isReloadingBomb = false;
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}