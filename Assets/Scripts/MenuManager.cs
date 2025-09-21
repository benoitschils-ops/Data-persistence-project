using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private TMP_InputField playerNameField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.interactable = false;
        GameModel.Instance.LoadScore();
    }

    public void NameChanged()
    {
        if (playerNameField.text != "") startGameButton.interactable = true;
        else startGameButton.interactable = false;
    }

    public void StartGame()
    {
        GameModel.Instance.playerName = playerNameField.text;
        SceneManager.LoadScene(1);
    }
}