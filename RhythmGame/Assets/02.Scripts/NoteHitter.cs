using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitter : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        // Miss ��������
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, 
                                        Constants.HIT_JUDGE_RANGE_MISS,
                                        0));
        // Bad ��������
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, 
                                        Constants.HIT_JUDGE_RANGE_BAD,
                                        0));
        // Good ��������
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, 
                                        Constants.HIT_JUDGE_RANGE_GOOD,
                                        0));
        // Great ��������
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, 
                                        Constants.HIT_JUDGE_RANGE_GREAT,
                                        0));
        // Cool ��������
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, 
                                        Constants.HIT_JUDGE_RANGE_COOL,
                                        0));
    }
}