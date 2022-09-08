using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateDropDestroy : MonoBehaviour
{
    [SerializeField] GameObject collisionObject;
    [SerializeField] bool limitToCollisionObject = false;
    [SerializeField] bool doesVibrate = true;
    [SerializeField] float vibrateMagnitude = .15f;
    [SerializeField] bool vibrateConstant = false;
    [SerializeField] float vibrateDurationSeconds = 2.5f;

    [SerializeField] bool doesDrop = true;

    [SerializeField] bool doesDelete = true;
    [SerializeField] float deleteDelaySeconds = 3;

    bool hasActivated = false;
    Vector3 startPosition;
    Rigidbody rigidBody;


    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (limitToCollisionObject && collision.gameObject != collisionObject) return;

        if (hasActivated) return;
        hasActivated = true;
        if (doesVibrate)
            StartCoroutine(Vibrate());
        if (doesDrop)
            StartCoroutine(Drop());
        if (doesDelete)
        {
            float timeToDeletion = deleteDelaySeconds;
            if (doesVibrate) timeToDeletion += vibrateDurationSeconds;
            Destroy(gameObject, timeToDeletion);
        }
    }


    IEnumerator Vibrate()
    {
        float elaspedTime = 0;
        while (elaspedTime < vibrateDurationSeconds)
        {
            float vibrateIntensity = VibrateCurveCalc(elaspedTime);
            transform.position = startPosition +
                UnityEngine.Random.insideUnitSphere * (vibrateMagnitude * vibrateIntensity);
            elaspedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPosition;
    }

    private float VibrateCurveCalc(float elaspedTime)
    {
        if (vibrateConstant) return 1;
        return elaspedTime / vibrateDurationSeconds;
    }
    IEnumerator Drop()
    {
        float elaspedTime = 0;
        if (doesVibrate)
            elaspedTime -= vibrateDurationSeconds;
        while (elaspedTime < 0)
        {
            elaspedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        rigidBody.isKinematic = false;
    }
}
