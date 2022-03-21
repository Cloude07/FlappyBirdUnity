using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Bird _saveData;

    private void OnEnable()
    {
        _saveData.LastScoreChanged += OnLastScoreChanged;
    }

    private void OnDisable()
    {
        _saveData.LastScoreChanged -= OnLastScoreChanged;
    }

    private void OnLastScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
