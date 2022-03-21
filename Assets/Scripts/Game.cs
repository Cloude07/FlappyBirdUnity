using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird; 
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndOverScreen _gameOverScreen;
    [SerializeField] private SaveData Save;


    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipeGenerator.ResetPoll();
        StartGame();
    }

    private void StartGame()
    {
        Save.LoadGame();
        Time.timeScale = 1;
        _bird.ResetPlayer();
        _birdMover._startMover = true;
    }

    public void OnGameOver()
    {
        Save.SaveGame();
        Time.timeScale = 0;
        _gameOverScreen.Open();
        _birdMover._startMover = false;
    }
}
