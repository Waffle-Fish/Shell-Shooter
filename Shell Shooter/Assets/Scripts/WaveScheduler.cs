using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScheduler : MonoBehaviour
{
    [Serializable]
    struct Wave {
        public GameObject gameObj;
        [Tooltip("When the wave is enabled since start of scene, in seconds")]
        public float timeToEnable;
    }

    [SerializeField]
    List<Wave> waves;

    float timer = 0f;
    int ind = 0;

    private void Awake() {
        foreach (var w in waves)
        {
            w.gameObj.SetActive(false);
        }    
    }

    void Update()
    {
        if (ind >= waves.Count) return;
        timer += Time.deltaTime;
        if (timer >= waves[ind].timeToEnable) {
            waves[ind].gameObj.SetActive(true);
            ind++;
        }
    }
}
