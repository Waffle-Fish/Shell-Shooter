using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField]
    float spawnDelay = 1f;
    List<EnemyHealth> enemiesList = new();
    float timer = 0f;
    int index = 0;

    private void Awake() {
        GetComponentsInChildren<EnemyHealth>(true, enemiesList);
        foreach (var enemy in enemiesList)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void Update() {
        if (index >= enemiesList.Count) return;
        if (timer <= 0f) {
            enemiesList[index].gameObject.SetActive(true);
            timer = spawnDelay;
            index++;
        } else {
            timer -= Time.deltaTime;
        }
    }
}
