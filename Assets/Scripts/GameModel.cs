using UnityEngine;
using System.IO;

public class GameModel : MonoBehaviour
{
    public static GameModel Instance;

    public string playerName;
    public string bestScorePlayerName;
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class BestScoreInfo
    {
        public string name;
        public int score;
    }

    public void SaveScore()
    {
        BestScoreInfo bestScoreInfo = new BestScoreInfo();
        bestScoreInfo.name = bestScorePlayerName;
        bestScoreInfo.score = bestScore;
        
        string json = JsonUtility.ToJson(bestScoreInfo);
        File.WriteAllText(Application.persistentDataPath + "/PlayerInfo.json", json);
    }
    
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/PlayerInfo.json";
        if (File.Exists(path))
        {
            BestScoreInfo bestScoreInfo = JsonUtility.FromJson<BestScoreInfo>(File.ReadAllText(path));
            bestScorePlayerName = bestScoreInfo.name;
            bestScore = bestScoreInfo.score;
        }
    }
}
