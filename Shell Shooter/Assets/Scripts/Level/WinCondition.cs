using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public enum StageType {Time, Elimination}
    // Time = Stage will end after a certain amount of time
    // Elimination = Stage will end after all enemies are defeated or have left the scene
    public StageType winCon = StageType.Time;

    [SerializeField]
    [Tooltip("How long the stage lasts, in seconds")]
    private float timeToClear;

    private void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
