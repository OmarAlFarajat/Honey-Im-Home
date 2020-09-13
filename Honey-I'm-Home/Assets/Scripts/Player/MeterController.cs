using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterController : MonoBehaviour
{
    DrunkPlayerMovement playerMeters;

    private void Awake()
    {
        playerMeters = GetComponent<DrunkPlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("obstacle"))
        {
            playerMeters.DrunkMeter += other.gameObject.GetComponent<ObstacleStats>().drunkDamage;

            if (playerMeters.DrunkMeter >= 100)
                playerMeters.DrunkMeter = 100;

            playerMeters.PainMeter += other.gameObject.GetComponent<ObstacleStats>().painDamage;

            if (playerMeters.PainMeter >= 100)
                playerMeters.PainMeter = 100;
        }
    }
}
