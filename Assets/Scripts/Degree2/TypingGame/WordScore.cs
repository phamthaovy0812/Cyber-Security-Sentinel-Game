using TMPro;
using UnityEngine;

public class WordScore : MonoBehaviour
{
    public static WordScore instance;
    public TMP_Text cur_score;
    private int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        cur_score.text = score.ToString();
    }
    public void UpdateScore()
    {
        score++;
        cur_score.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
}