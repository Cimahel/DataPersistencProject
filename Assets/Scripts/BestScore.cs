using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text _text;

    public int bestScore;
    public string bestPlayerName;
    // Start is called before the first frame update

    void Start()
    {
        if (ScoreKeeper.instance != null)
        {
            bestScore = ScoreKeeper.instance.bestScore;
            bestPlayerName = ScoreKeeper.instance.bestPlayername;
            _text.text = "Best Score : " + bestPlayerName + " : " + bestScore;
        }
        
    }
}
