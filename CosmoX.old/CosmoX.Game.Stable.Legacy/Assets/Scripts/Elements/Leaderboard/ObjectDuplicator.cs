using UnityEngine;
using TMPro;

public class ObjectDuplicator : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public int numDuplicates = 5;
    public float verticalSpacing = 2.0f;
    public TMP_Text playerNameTextPrefab;  // Reference to the TMP text prefab for player name
    public TMP_Text playerPlacementTextPrefab;  // Reference to the TMP text prefab for player placement
    public TMP_Text playerPPTextPrefab;  // Reference to the TMP text prefab for player PP
    public TMP_Text playerAccuracyTextPrefab;  // Reference to the TMP text prefab for player accuracy
    public TMP_Text playerTotalScoresTextPrefab;  // Reference to the TMP text prefab for player total scores
    public TMP_Text playerPlayCountsTextPrefab;  // Reference to the TMP text prefab for player play counts

    private int[] playerPP;
    private float[] playerAccuracy;
    private int[] playerTotalScores;
    private int[] playerPlayCounts;

    void Start()
    {
        if (objectToDuplicate != null)
        {
            InitializeLeaderboard();
            DuplicateObjects();
            DisplayLeaderboard();
        }
        else
        {
            Debug.LogWarning("Please assign an object to duplicate.");
        }
    }

    void InitializeLeaderboard()
    {
        int numPlayers = numDuplicates + 1;
        playerPP = new int[numPlayers];
        playerAccuracy = new float[numPlayers];
        playerTotalScores = new int[numPlayers];
        playerPlayCounts = new int[numPlayers];

        // Sample data for the original object
        playerPP[0] = 1000;  // Sample PP for the original object
        playerAccuracy[0] = 95.0f;  // Sample accuracy for the original object
        playerTotalScores[0] = 5000000;  // Sample total scores for the original object
        playerPlayCounts[0] = 100;  // Sample play counts for the original object
    }

    void DuplicateObjects()
    {
        Vector3 startingPosition = objectToDuplicate.transform.position;

        GameObject firstDuplicate = Instantiate(objectToDuplicate, startingPosition, Quaternion.identity, transform);
        firstDuplicate.name = "Player 1";

        InstantiatePlayerText(playerPlacementTextPrefab, firstDuplicate, "#1");
        InstantiatePlayerText(playerNameTextPrefab, firstDuplicate, "Player 1");
        InstantiatePlayerText(playerPPTextPrefab, firstDuplicate, FormatScore(playerPP[0]));
        InstantiatePlayerText(playerAccuracyTextPrefab, firstDuplicate, playerAccuracy[0].ToString("F1") + "%");
        InstantiatePlayerText(playerTotalScoresTextPrefab, firstDuplicate, FormatScore(playerTotalScores[0]));
        InstantiatePlayerText(playerPlayCountsTextPrefab, firstDuplicate, FormatPlayCounts(playerPlayCounts[0]));

        for (int i = 2; i <= numDuplicates + 1; i++)
        {
            Vector3 spawnPosition = startingPosition - new Vector3(0, (i - 1) * verticalSpacing, 0);
            GameObject newObj = Instantiate(objectToDuplicate, spawnPosition, Quaternion.identity, transform);

            newObj.name = "Player " + i;

            InstantiatePlayerText(playerPlacementTextPrefab, newObj, "#" + i);
            InstantiatePlayerText(playerNameTextPrefab, newObj, "Player " + i);
            InstantiatePlayerText(playerPPTextPrefab, newObj, FormatScore(playerPP[i - 1]));
            InstantiatePlayerText(playerAccuracyTextPrefab, newObj, playerAccuracy[i - 1].ToString("F1") + "%");
            InstantiatePlayerText(playerTotalScoresTextPrefab, newObj, FormatScore(playerTotalScores[i - 1]));
            InstantiatePlayerText(playerPlayCountsTextPrefab, newObj, FormatPlayCounts(playerPlayCounts[i - 1]));
        }
    }

    void DisplayLeaderboard()
    {
        // Display the leaderboard in the stats text
        // Assuming you have a main text object that displays the leaderboard
        // Adjust these texts according to your UI setup
        GameObject leaderboardUI = GameObject.Find("LeaderboardUI");

        if (leaderboardUI != null)
        {
            string leaderboardStats = "Leaderboard:\n";

            for (int i = 0; i < playerPP.Length; i++)
            {
                leaderboardStats += $"Player #{i + 1}\n";
                leaderboardStats += $"  Placement: {FormatScore(i + 1)}\n";
                leaderboardStats += $"  PP: {FormatScore(playerPP[i])}\n";
                leaderboardStats += $"  Accuracy: {playerAccuracy[i]}%\n";
                leaderboardStats += $"  Total Scores: {FormatScore(playerTotalScores[i])}\n";
                leaderboardStats += $"  Play Counts: {FormatPlayCounts(playerPlayCounts[i])}\n";
            }

            leaderboardUI.GetComponent<TMP_Text>().text = leaderboardStats;
        }
        else
        {
            Debug.LogWarning("LeaderboardUI object not found. Please provide the correct UI object name.");
        }
    }

    void InstantiatePlayerText(TMP_Text textPrefab, GameObject parentObject, string text)
    {
        TMP_Text playerTextInstance = Instantiate(textPrefab, parentObject.transform);
        playerTextInstance.text = text;
    }

    string FormatScore(int score)
    {
        if (score >= 1000000)
            return $"{score / 1000000}M";
        else if (score >= 1000)
            return $"{score / 1000}K";
        else
            return score.ToString();
    }

    string FormatPlayCounts(int playCounts)
    {
        if (playCounts >= 1000000)
            return $"{playCounts / 1000000}M";
        else if (playCounts >= 1000)
            return $"{playCounts / 1000}K";
        else
            return playCounts.ToString();
    }
}
