using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject movePatternObj;
    private EnemyMovePattern movePattern;

    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float PointMarginOfError = 0.5f;

    Vector3 boundSize = Vector3.one;
    Bounds pointBounds;
    Bounds finalBounds;
    int posIndex = 1;

    private void Awake() {
        movePattern = movePatternObj.GetComponent<EnemyMovePattern>();
    }

    private void Start() {
        boundSize *= PointMarginOfError;
        finalBounds = new Bounds(movePattern.Positions[^1], boundSize);
        Initialize();
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        transform.position = movePattern.Positions[0];
        posIndex = 1;
        UpdatePointBounds();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMove();
    }

    private void ProcessMove()
    {
        if (finalBounds.Contains(transform.position) && posIndex >= movePattern.Positions.Count) return;
        MoveTo();
        if (pointBounds.Contains(transform.position))
        {
            posIndex++;
            if (posIndex >= movePattern.Positions.Count) {
                if (movePattern.loop) posIndex = 0;
                else {
                    gameObject.SetActive(false);
                    return;
                };
            }
            UpdatePointBounds();
        }
    }

    void MoveTo() {
        Vector3 translation =  moveSpeed * Time.deltaTime * (movePattern.Positions[posIndex] - transform.position).normalized;
        transform.Translate(translation);
    }

    void UpdatePointBounds() {
        pointBounds = new Bounds(movePattern.Positions[posIndex], boundSize);
    }
}
