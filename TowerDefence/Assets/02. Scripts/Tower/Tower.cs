using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // PascalCase
    // camelCase
    // _camelCase 

    public TowerInfo info;
    public Node node;

    protected Transform tr;
    [SerializeField] private Transform rotatePoint;
    [SerializeField] protected float detectRange;
    [SerializeField] protected LayerMask targetLayer;
    [SerializeField] protected LayerMask touchlayer;
    protected Transform target;



    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, targetLayer);

        if (cols.Length > 0)
        {
            target = cols[0].transform;
            rotatePoint.LookAt(target);
        }
        else
        {
            target = null;
        }
    }

    private void OnMouseDown()
    {
        if (TowerHandler.instance.gameObject.activeSelf == false)
            TowerUI.instance.SetUp(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
