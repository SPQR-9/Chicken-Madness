using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatcherView : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Carrier _carrier;

    private void OnEnable() => _carrier.CountChanged += ShowNewScore;

    private void OnDisable() => _carrier.CountChanged -= ShowNewScore;

    private void ShowNewScore(int score) => _text.text = score.ToString();
}
