using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject middleLane;

    public IEnumerator Shake(float duration, float magnitude) {
        //Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration) {

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x + middleLane.transform.position.x, y + middleLane.transform.position.y, -10);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = new Vector3(middleLane.transform.position.x, middleLane.transform.position.y, -10);
        //originalPos;
    }
}
