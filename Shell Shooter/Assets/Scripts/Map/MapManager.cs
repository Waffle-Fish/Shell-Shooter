using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    [Min(2)]
    int maxNumCols = 2;
    [SerializeField]
    [Min(1)]
    int minNumRows = 1;
    [SerializeField]
    [Range(1, 10)]
    int maxNumRows = 2;
    [SerializeField]
    GameObject BattleNode;
    [SerializeField]
    GameObject SailNode;
    [SerializeField]
    GameObject SanctuaryNode;
    [SerializeField]
    GameObject BossNode;

    [SerializeField]
    List<List<GameObject>> gameMap = new();
    RectTransform mapRT;
    float startXPosAnchor = 0.15f;
    float endXPosAnchor = 0.85f;
    float midYPosAnchor = 0.4f;

    // [Button]
    // public void CreateMapButton() {
    //     CreateMap();
    // }

    private void Awake()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        // Initialize
        if (maxNumRows < minNumRows) maxNumRows = minNumRows;
        mapRT = GetComponent<RectTransform>();

        // Set up map
        GameObject startNode = Instantiate(SanctuaryNode, transform);
        RectTransform startNodeRT = startNode.GetComponent<RectTransform>();
        startNodeRT.anchorMin = new(startXPosAnchor, midYPosAnchor);
        startNodeRT.anchorMax = new(startXPosAnchor, midYPosAnchor);
        startNode.SetActive(true);
        int numRows = UnityEngine.Random.Range(minNumRows, maxNumRows+1);

        List<GameObject> col1 = new() { startNode };
        gameMap.Add(col1);
        float anchorLength = endXPosAnchor - startXPosAnchor;
        float anchorXSpacing = anchorLength / (maxNumCols - 1);
        float anchorYSpacing = anchorLength / numRows;
        

        for (int i = 1; i < maxNumCols - 1; i++)
        {
            List<GameObject> col = new();
            for (int j = 0; j < numRows; j++)
            {
                int nodeType = UnityEngine.Random.Range(0, 3);
                GameObject choosenNode = nodeType switch
                {
                    0 => SailNode,
                    1 => BattleNode,
                    2 => SanctuaryNode,
                    _ => SailNode,
                };
                GameObject newNode = Instantiate(choosenNode, transform);
                RectTransform newNodeRT = newNode.GetComponent<RectTransform>();
                newNodeRT.anchorMin = new(anchorXSpacing * i + startXPosAnchor, anchorYSpacing * (numRows - j));
                newNodeRT.anchorMax = new(anchorXSpacing * i + startXPosAnchor, anchorYSpacing * (numRows - j));
                newNode.SetActive(true);
                col.Add(newNode);
            }
            gameMap.Add(col);
        }

        GameObject endNode = Instantiate(BossNode, transform);
        RectTransform endNodeRT = endNode.GetComponent<RectTransform>();
        endNodeRT.anchorMin = new(endXPosAnchor, midYPosAnchor);
        endNodeRT.anchorMax = new(endXPosAnchor, midYPosAnchor);
        endNode.SetActive(true);
    }
}
