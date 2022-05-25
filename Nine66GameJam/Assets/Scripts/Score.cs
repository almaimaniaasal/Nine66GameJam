using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scorePlayerText;
    public Text ScoreTextLeaderboard;
    static int score = 0;
    int cubeNum;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text numberText = GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
        cubeNum = int.Parse(numberText.text);
        score += cubeNum;
    }

    public static int totalScore
	{
		get { return score; }
        set{score = value;}
	}

    // Update is called once per frame
    void Update()
    {
        scorePlayerText.GetComponent<Text>().text=score.ToString();
        ScoreTextLeaderboard.text=score.ToString();
        Debug.Log(score);
    }
}
