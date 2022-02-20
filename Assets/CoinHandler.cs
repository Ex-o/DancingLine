using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    private int _phase = -1;
    static int _coinCnt = 0;
    private void Update()
    {
        transform.Rotate(0, 2, 0, Space.World);
        Vector3 np = transform.position;
        np.y += -Math.Sign(_phase) * 0.2f;
        _phase = -_phase;
        transform.position = np;
        WaitPhase();
    }

    private IEnumerator WaitPhase()
    {
        yield return new WaitForSeconds(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coinCnt++;
            Debug.Log($"{_coinCnt} coins collected.");
            Destroy(gameObject);
        }
    }
}