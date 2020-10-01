using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrunkPlayerMovement : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float _drunkMeter = 70;

    public float DrunkMeter { get { return _drunkMeter; } set { _drunkMeter = value; } }

    [Range(0, 100)]
    [SerializeField] private float _painMeter = 0;

    public float PainMeter { get { return _painMeter; } set { _painMeter = value; } }

    [Range(1, 100)]
    [SerializeField] private float _drunkForceDivider = 5;

    [Range(1, 10000)]
    [SerializeField] private float _guidingForceMultiplier = 4000;

    private Rigidbody2D _rb2d;

    private int _drunkMovementDirection;
    private float _drunkMovementChangeTimer;
    private float _drunkForce = 0;
    private float _guidingForce = 0;

    private float nextActionTime = 0.0f;
    private const float period = 4.258f;    // Exact length of walking sound clip

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        // -1 -> Left, 1 -> Right
        _drunkMovementDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        _drunkMovementChangeTimer = getRandomDurationForTimer();

        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        changeDrunkMovementDirection();
    }

    private void FixedUpdate()
    {
        playWalkingSound();
        applyDrunkForce();
        applyGuidingForce();
        Die();
    }

    private void applyDrunkForce()
    {
        _drunkForce = Time.deltaTime * (_drunkMeter * _drunkMovementDirection) / _drunkForceDivider;
        _rb2d.AddForce(new Vector2(_drunkForce, 0));
    }

    private void applyGuidingForce()
    {
        float guidingForceDirection = Input.GetAxisRaw("Horizontal");

        if (_drunkMeter <= 10)
        {
            _guidingForceMultiplier = 500;
        }
        else
        {
            _guidingForceMultiplier = 4000;
        }

        _guidingForce = (1 / _drunkMeter) * Time.deltaTime * -guidingForceDirection * _guidingForceMultiplier;
        _drunkForce -= _guidingForce;
        _rb2d.AddForce(new Vector2(_drunkForce, 0));

    }

    private void changeDrunkMovementDirection()
    {
        if (_drunkMovementChangeTimer > 0)
        {
            _drunkMovementChangeTimer -= Time.deltaTime;
            return;
        }

        _drunkMovementDirection *= -1;
        _drunkMovementChangeTimer = getRandomDurationForTimer();
    }

    private float getRandomDurationForTimer()
    {
        return Random.Range(1, 6);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            Destroy(other.gameObject);
            audioManager.Play("hurt");
        }
        if (other.gameObject.CompareTag("beer"))
        {
            Destroy(other.gameObject);
            audioManager.Play("drink");
        }
    }

    private void Die()
    {
        if (PainMeter >= 100f || DrunkMeter >= 100f)
        {
            audioManager.StopCurrent();
            audioManager.Stop("walk");
            SceneManager.LoadScene("Fail");
        }
    }

    // Walking sound is only played when movement keys are pressed and in periods of ~4 seconds (audio clip length)
    private void playWalkingSound()
    {
        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            if (Time.timeSinceLevelLoad > nextActionTime)
            {
                nextActionTime = Time.timeSinceLevelLoad + period;
                audioManager.Play("walk");
            }
        }
        else
            audioManager.Stop("walk");
    }


}
