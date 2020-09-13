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

            StartCoroutine(Shake(0.5f, 0.025f));

            playerMeters.DrunkMeter += other.gameObject.GetComponent<ObstacleStats>().drunkDamage;

            if (playerMeters.DrunkMeter >= 100)
                playerMeters.DrunkMeter = 100;

            playerMeters.PainMeter += other.gameObject.GetComponent<ObstacleStats>().painDamage;

            if (playerMeters.PainMeter >= 100)
                playerMeters.PainMeter = 100;
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = Camera.main.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        Camera.main.transform.position = orignalPosition;
    }

}
