using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWave : MonoBehaviour
{
    [Serializable]
    struct Pair {
        public GameObject wave;
        [Tooltip("In seconds")]
        public float timeToEnable;
    }

    [SerializeField]
    List<Pair> waves;

    float timer = 0f;
    int ind = 0;

    private void Awake() {
        foreach (var w in waves)
        {
            w.wave.SetActive(false);
        }    
    }

    void Update()
    {
        if (ind >= waves.Count) return;
        timer += Time.deltaTime;
        if (timer >= waves[ind].timeToEnable) {
            waves[ind].wave.SetActive(true);
            ind++;
        }
    }
}
