using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List <StageInfo> stageList = new List<StageInfo>();
    private List <float[]> timersList = new List<float[]>();
    private List <float[]> delayTimerList = new List<float[]>();
    private Transform[] spawnPoints;
    private Transform[] goalPoints;

    public void SpawnEnemy(StageInfo stageInfo)
    {
        stageList.Add(stageInfo);
        float[] tmpTimerList = new float[stageInfo.enemySpawnDataList.Count];
        float[] tmpDelayTimerList = new float[stageInfo.enemySpawnDataList.Count];

        for (int i = 0; i < tmpTimerList.Length; i++)
        {
            tmpTimerList[i] = stageInfo.enemySpawnDataList[i].delay;
        }
        for (int i = 0; i < tmpDelayTimerList.Length; i++)
        {
            tmpTimerList[i] = stageInfo.enemySpawnDataList[i].delay;
        }

        timersList.Add(tmpTimerList);
        delayTimerList.Add(tmpDelayTimerList);
    }

    private void Update()
    {
        for (int i = 0; i < stageList.Count; i++)
        {
            for (int j = 0; j < stageList[i].enemySpawnDataList.Count; j++)
            {
                if (delayTimerList[i][j] < 0)
                {
                    if (timersList[i][j] < 0)
                    {
                        GameObject go = Instantiate(stageList[i].enemySpawnDataList[j].poolElement.prefab, spawnPoints[i].position, Quaternion.identity);
                        go.GetComponent<Pathfinder>().FindOptimizedPath(spawnPoints[stageList[i].enemySpawnDataList[j].spawnPointIndex],
                                                                        goalPoints[stageList[i].enemySpawnDataList[j].goalPointIndex]);
                        timersList[i][j] = stageList[i].enemySpawnDataList[j].term;
                    }
                    else
                    {
                        timersList[i][j] -= Time.deltaTime;
                    }
                }
                else
                {
                    delayTimerList[i][j] -= Time.deltaTime;
                }
            }
        }
        
    }
}