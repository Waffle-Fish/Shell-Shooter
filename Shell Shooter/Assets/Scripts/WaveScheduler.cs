using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
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

    [Button]
    public void OrganizeWaves() {
        waves.Sort(delegate(Wave x, Wave y) {
            return (int)(x.timeToEnable - y.timeToEnable);
        });
    }

    private void Awake() {
        foreach (var w in waves)
        {
            w.gameObj.SetActive(false);
        }    
        OrganizeWaves();
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

    public float GetLastWaveTimeToEnable() {
        if (waves.Count == 0) return -1f;
        return waves[^1].timeToEnable;
    }
}
