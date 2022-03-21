using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> LastScoreChanged;
    [SerializeField] private SaveData Save;
    [SerializeField] private SoundComponent Sound;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        LastScoreChanged?.Invoke(Save.IntegerSave);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        LastScoreChanged?.Invoke(Save.IntegerSave);
        _mover.ResetBird();
    }

    public void Die()
    {
        Sound.SoundHit();
        GameOver?.Invoke();
    }

    public void IncreaseScore()
    {
        _score ++;
        Sound.SoundCountUp();
        SaveLastScore();
        ScoreChanged?.Invoke(_score);
    }

    private void SaveLastScore()
    {
        if(_score > Save.IntegerSave)
        {
            Save.IntegerSave = _score;
            LastScoreChanged?.Invoke(_score);
        }
        else
            LastScoreChanged?.Invoke(Save.IntegerSave);
    }
}
