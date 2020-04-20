using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI text;

    private int oldScore;
    // Start is called before the first frame update
    void Start()
    {
        oldScore = GameManager.Score;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Score != oldScore)
        {
            text.text = GameManager.Score.ToString();
            oldScore = GameManager.Score;
        }
    }
}
