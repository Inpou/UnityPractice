using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static int Score;
    public static int Combo;
    private static int _previousCombo;
    private float _timer;
    private Text _scoreText;
    private Text _comboText;

    private void Awake()
    {
        _scoreText = GameObject.Find("Score").GetComponent<Text>();
        _comboText = GameObject.Find("Combo").GetComponent<Text>();
        Score = 0;
        Combo = 0;
        _previousCombo = 0;
    }


    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 60f && _previousCombo == Combo)
            Combo = (int) (_timer = 0f);
        _comboText.text = "Combo: " + (Combo);
        _scoreText.text = "Score: " + Score;
        _previousCombo = Combo;
    }
}