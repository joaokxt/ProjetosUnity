using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _livesText;

    public void UpdateCoins(int coins)
    {
        _coinText.text = "Moedas: " + coins;
    }

    public void UpdateLives(int lives)
    {
        _livesText.text = "Vidas: " + lives;
    }
}
