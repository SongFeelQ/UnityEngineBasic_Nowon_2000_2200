using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    public bool isGoUpPossible;
    public bool isGoDownPossible;

    private float _ladderAtHeadStartOffsetY = 0.03f;
    private float _ladderAtFeetStartOffsetY = 0.33f;

    private float _playerSizeY;
    private CapsuleCollider2D _col;
    private Rigidbody2D _rb;
    [SerializeField] private LayerMask _ladderLayer;

    private Vector2 _ladderTopPoint;
    private Vector2 _ladderBottomPoint;
    private float _detectHeightOffset;

    private void Awake()
    {
        _col = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Collider2D ladderCol = Physics2D.OverlapCircle(new Vector2(_rb.position.x, _rb.position.y + _col.offset.y + _col.size.y),
                                                       0.01f,
                                                       _ladderLayer);

        
        ladderCol = Physics2D.OverlapCircle(new Vector2(_rb.position.x, _rb.position.y + _col.offset.y - _col.size.y * _detectHeightOffset),
                                            0.01f, 
                                            _ladderLayer);

        if (ladderCol != null)
        {
            BoxCollider2D ladderBoxCol = (BoxCollider2D)ladderCol;
            _ladderTopPoint = (Vector2)ladderBoxCol.transform.position + ladderBoxCol.offset + Vector2.up * ladderBoxCol.size.y / 2f;
            _ladderBottomPoint = (Vector2)ladderBoxCol.transform.position + ladderBoxCol.offset + Vector2.down * ladderBoxCol.size.y / 2f;
        }
        else
        {
            isGoUpPossible = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (_rb == null) return;

        Gizmos.color = Color.magenta;
    }
}
