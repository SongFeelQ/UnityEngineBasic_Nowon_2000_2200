using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI instance;
    [SerializeField] private Image _image;
    [SerializeField] private float _animationDeley;
    [SerializeField] private float _animationTime;
    private float _timer;
    private List<Sprite> sprites = new List<Sprite> ();

    private void Awake()
    {
        LoadSprites();
    }

    private void LoadSprites()
    {
        sprites = Resources.LoadAll<Sprite>("DiceImages").ToList();
       
    }

    private void Update()
    {
        if (_timer < 0)
        {
            _image.sprite = sprites[Random.Range(0, sprites.Count)];
            _timer = _animationDeley;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }


    public void DoDiceAnimation()
    {
        StartCoroutine(E_DiceAnimation());
    }

    IEnumerator E_DiceAnimation()
    {
        float elapsedTime = 0;
        while (elapsedTime < _animationTime)
        {
            if (_timer < 0)
            {
                _image.sprite = sprites[Random.Range(0, sprites.Count)];
                _timer = _animationDeley;
            }
            _timer -= Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //while(elapsedTime < _animationTime)
        //{
        //    _image.sprite = sprites[Random.Range(0, sprites.Count)];
        //    yield return new WaitForSeconds(_animationDeley);
        //}
        yield return null;
    }
}
