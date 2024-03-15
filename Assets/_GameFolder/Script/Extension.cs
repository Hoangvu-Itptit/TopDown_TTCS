using System;
using System.Collections;
using UnityEngine;

public static class Extension
{
    public static void StartDelayAction(this MonoBehaviour mono, float waitTime, Action callback)
    {
        mono.StartCoroutine(CoroutineDelay(callback, waitTime));
    }

    private static IEnumerator CoroutineDelay(Action callback, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        callback.Invoke();
    }

    public static void StartDelayAction(this MonoBehaviour mono, Func<bool> condition, Action callback)
    {
        mono.StartCoroutine(CoroutineDelay(condition, callback));
    }

    private static IEnumerator CoroutineDelay(Func<bool> condition, Action callback)
    {
        yield return new WaitUntil(condition);
        callback.Invoke();
    }
}