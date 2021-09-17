using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int baseLives = 3;
    float lives = 5;
    Text livesText;
    // Start is called before the first frame update
    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }
    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
