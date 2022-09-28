using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    public enum States
    {
        Idle,
        SetUpLevel,
        PlayStartEvents,
        WaitForStartEvents,
        PlayStage,
        WaitForStageFinished,
        NextStage,
        LevelCompleted,
        LevelFailed,
        WaitForUser,
    }
    public States state;
    public LevelInfo levelInfo;
    public int stage;
    [SerializeField] private EnemySpawner _spawner;

    public void StartLevel()
    {
        if (state == States.Idle)
            state = States.PlayStartEvents;
    }

    private void Awake()
    {
        instance = this;
        StartCoroutine(E_Init());
    }

    IEnumerator E_Init()
    {
        yield return new WaitUntil(() => Player.instance);
        Player.instance.SetUp(levelInfo.lifeInit,
                              levelInfo.moneyInit);
    }

    private void Update()
    {
        switch (state)
        {
            case States.Idle:
                break;
            case States.SetUpLevel:
                {
                    Pathfinder.SetNodeMap();
                    state = States.PlayStartEvents;
                }
                break;
            case States.PlayStartEvents:
                {
                    state = States.WaitForStartEvents;
                }
                break;
            case States.WaitForStartEvents:
                {
                    state = States.PlayStage;
                }
                break;
            case States.PlayStage:
                {
                    _spawner.SpawnEnemy(levelInfo.stageInfo[currentStage]);
                    state = States.WaitForStageFinished;
                }
                break;
            case States.WaitForStageFinished:
                break;
            case States.NextStage:
                {
                    if (currentStage >= levelInfo.stageInfo.Count - 1)
                        state = States.LevelCompleted;
                }
                break;
            case States.LevelCompleted:
                break;
            case States.LevelFailed:
                break;
            case States.WaitForUser:
                break;
            default:
                break;
        }
    }

    private void MoveNext()
    {
        if (state < States.WaitForUser)
        {

        }
    }
}
