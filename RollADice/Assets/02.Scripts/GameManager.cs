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
    public int diceNum
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
    public int goldenDiceNum
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

    // direction 1: positive, -1: negative
    private int _direction;
    public int direction
    {
        get
        {
            return _direction;
        }
        set
        {
            if (value < 0)
            {
                _direction = Constants.DIRECTION_NEGATIVE;
                _inverseIcon.SetActive(true);
            }
            else
            {
                _direction = Constants.DIRECTION_POSITIVE;
                _inverseIcon.SetActive(false);
            }
        }
    }
    [SerializeField] private GameObject _inverseIcon;

    private int _tilesCount;
    private int _current;

    public void RollADice()
    {
        if (_diceNum > 0 && 
            DiceAnimationUI.instance.isPlaying == false)
        {
            diceNum--;
            int randomValue = Random.Range(1, 7);
            DiceAnimationUI.instance.DoDiceAnimation(randomValue);
        }
    }

    public void RollAGoldenDice(int diceValue)
    {
        if (_goldenDiceNum > 0 &&
            DiceAnimationUI.instance.isPlaying == false)
        {
            goldenDiceNum--;
            DiceAnimationUI.instance.DoDiceAnimation(diceValue);
        }
    }

    private void MovePlayer(int diceValue)
    {
        if (_direction > 0)
        {
            CalcPassedStarStarTiles(_current, diceValue);

            _current += diceValue;
            if (_current >= _tilesCount)
                _current -= _tilesCount;
        }
        else
        {
            _current -= diceValue;
            if (_current < 0)
                _current += _tilesCount;
            direction = Constants.DIRECTION_POSITIVE;
        }
        
        

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
        direction = Constants.DIRECTION_POSITIVE;
        _tiles.Sort();
        _tilesCount = _tiles.Count;

        foreach (var tile in _tiles)
        {
            // is 연산자
            // 캐스트 후의 결과 반환하는 연산자
            // 캐스팅 성공하면 true 반환, 실패하면 false 반환
            if (tile is TileInfoStar)
            {
                _starTiles.Add((TileInfoStar)tile);
            }

            // as 명시적 캐스팅연산자
            // 형변환 실패시 null 반환.
            //TileInfoStar tmp = tile as TileInfoStar;
            //if (tmp != null)
            //    _starTiles.Add(tmp);

        }
    }

    private void Start()
    {
        DiceAnimationUI.instance.RegisterCallBack(MovePlayer);
    }
}
