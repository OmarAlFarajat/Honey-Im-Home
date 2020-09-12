using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkPlayerMovement : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float _drunkMeter = 25;

    [Range(0, 100)]
    [SerializeField] private float _painMeter = 25;

    [Range(1, 100)]
    [SerializeField] private float _drunkForceDivider = 7;

    [Range(1, 10000)]
    [SerializeField] private float _guidingForceMultiplier = 5000;

    private Rigidbody2D _rb2d;

    private int _drunkMovementDirection;
    private float _drunkMovementChangeTimer;
    private float _drunkForce = 0;
    private float _guidingForce = 0;

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
        applyDrunkForce();
        applyGuidingForce();
        Debug.Log("DRUNK FORCE " + _drunkForce);
        Debug.Log("GUIDING FORCE " + _guidingForce);
    }

    private void applyDrunkForce()
    {
        _drunkForce = Time.deltaTime * (_drunkMeter * _drunkMovementDirection) / _drunkForceDivider;
        _rb2d.AddForce(new Vector2(_drunkForce, 0));
    }

    private void applyGuidingForce()
    {
        float guidingForceDirection = Input.GetAxisRaw("Horizontal");
        Debug.Log("GUIDING FORCE DIRECTION " + guidingForceDirection);

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
}
