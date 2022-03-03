using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class ScoreKeeper : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string bestPlayername;
        public int bestScore;
    }

    public static ScoreKeeper instance;

    public string bestPlayername;
    public int bestScore;

    public string playerName;

    // Start is called before the first frame update
    void Awake()
    {
        if (ScoreKeeper.instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    public void UpdateBestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestPlayername = playerName;

            SaveBestScore();
        }
    }

    public void PlayerNameUpdate(string input)
    {
        playerName = input;
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
            bestPlayername = data.bestPlayername;
        }
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestPlayername = bestPlayername;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
