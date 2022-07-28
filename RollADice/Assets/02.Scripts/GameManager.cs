using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<TileInfo> _tiles;
    private List<TileInfoStar> _starTiles = new List<TileInfoStar>();
    private int _starScore;
    private int starScore
    {
        get => _starScore;
        set
        {
            _starScore = value;
            _starScoreText.text = _starScore.ToString();
        }
    }
    [SerializeField] private Text _starScoreText;
    private int _diceNum;
    private int diceNum
    {
        get
        {
            return _diceNum;
        }
        set
        {
            _diceNum = value;
            _diceNumText.text = _diceNum.ToString();
        }
    }
    [SerializeField] private Text _diceNumText;

    private int _goldenDiceNum;
    private int goldenDiceNum
    {
        get
        {
            return _goldenDiceNum;
        }
        set
        {
            _goldenDiceNum = value;
            _goldenDiceNumText.text = _goldenDiceNum.ToString();
        }
    }
    [SerializeField] private Text _goldenDiceNumText;

    private int _tilesCount;

    private int _current;

    public void RollADice()
    {
        if (_diceNum > 0)
        {
            diceNum--;
            int randomValue = Random.Range(1, 7);
            DiceAnimationUI.instance.DoDiceAnimation();
            MovePlayer(randomValue);
        }
    }

    public void RollAGoldenDice()
    {
        if (_goldenDiceNum > 0)
        {
            goldenDiceNum--;
        }
    }

    private void MovePlayer(int diceValue)
    {
        CalcPassedStarStarTiles(_current, diceValue);
        _current += diceValue;
        if (_current >= _tilesCount)
            _current -= _tilesCount;

        Player.instance.MoveTo(_tiles[_current].transform);
        _tiles[_current].OnTile();
    }    

    private void CalcPassedStarStarTiles(int previous, int totalMove)
    {
        int tmpSum = 0;
        foreach (TileInfoStar starTile in _starTiles)
        {
            if (starTile.index > previous &&
                starTile.index <= previous + totalMove)
            {
                tmpSum += starTile.starValue;
            }
        }
        starScore = starScore + tmpSum;
    }

    private void Awake()
    {
        instance = this;
        _diceNum = Constants.DICE_NUM_INIT;
        _goldenDiceNum = Constants.GOLDEN_DICE_NUM_INIT;
        _tiles.Sort();
        _tilesCount = _tiles.Count;

        foreach (var tile in _tiles)
        {
            // is ������
            // ĳ��Ʈ ���� ��� ��ȯ�ϴ� ������
            // ĳ���� �����ϸ� true ��ȯ, �����ϸ� false ��ȯ
            if (tile is TileInfoStar)
            {
                _starTiles.Add((TileInfoStar)tile);
            }

            // as ����� ĳ���ÿ�����
            // ����ȯ ���н� null ��ȯ.
            //TileInfoStar tmp = tile as TileInfoStar;
            //if (tmp != null)
            //    _starTiles.Add(tmp);

        }
    }
}
