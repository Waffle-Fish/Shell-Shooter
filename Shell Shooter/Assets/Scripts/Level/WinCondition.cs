using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System;

public class WinCondition : MonoBehaviour
{
    public bool Win {get; private set;} = false;

    public enum StageType {Time, Elimination}
    // Time = Stage will end after a certain amount of time
    // Elimination = Stage will end after all enemies are defeated or have left the scene
    public StageType winCon = StageType.Time;

    [SerializeField]
    [Tooltip("How long the stage lasts, in seconds")]
    private float timeToClear;
    [SerializeField]
    [Tooltip("How long the stage lasts, in seconds")]
    private WaveScheduler waveScheduler;
    private float timer = 0f;
    private int curEnemyCount;

    private void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Win) return;
        timer += Time.deltaTime;
        CheckWinCon();
    }

    private void CheckWinCon() {
        switch (winCon) {
            case StageType.Time:
                if (timer >= timeToClear) {
                    Debug.Log("Time victory!");
                    Win = true;
                }
            break;
            case StageType.Elimination:
                if (timer >= waveScheduler.GetLastWaveTimeToEnable()) {
                    curEnemyCount = waveScheduler.GetComponentsInChildren<EnemyHealth>(true).Length;
                    if (curEnemyCount == 0) {
                        Debug.Log("Elimination Victory!");
                        Win = true;
                    }
                }
            break;
        }
    }
}
