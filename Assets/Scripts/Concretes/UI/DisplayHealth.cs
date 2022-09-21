using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    TextMeshProUGUI _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealthText(int health)
    {
        _healthText.text = health.ToString();
    }
}
