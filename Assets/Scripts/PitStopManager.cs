
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PitStopManager : MonoBehaviour
{
    [Header("Game Settings")]
    public float startingTime = 60f;

    [Header("Game Objects")]
    public GameObject releaseButton;
    public VictoryCarSpin victoryCarSpin;

    [Header("UI")]
    public TMP_Text timerText;
    public TMP_Text statusText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip installSound;
    public AudioClip tightenSound;
    public AudioClip winSound;

    private bool tyreInstalled = false;
    private bool wheelTightened = false;
    private bool gameOver = false;
    private bool playerWon = false;

    private float timeRemaining;

    void Start()
    {
        timeRemaining = startingTime;

        if (releaseButton != null)
        {
            releaseButton.SetActive(false);
        }

        UpdateUI();
    }

    void Update()
    {
        if (gameOver)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            gameOver = true;
            playerWon = false;

            if (releaseButton != null)
            {
                releaseButton.SetActive(false);
            }
        }

        UpdateUI();
    }

    public void InstallTyre()
    {
        if (gameOver)
            return;

        tyreInstalled = true;

        PlaySound(installSound);
        UpdateUI();
    }

    public void RemoveTyre()
    {
        if (gameOver)
            return;

        tyreInstalled = false;
        wheelTightened = false;

        if (releaseButton != null)
        {
            releaseButton.SetActive(false);
        }

        UpdateUI();
    }

    public void TightenWheel()
    {
        if (gameOver || !tyreInstalled || wheelTightened)
            return;

        wheelTightened = true;

        if (releaseButton != null)
        {
            releaseButton.SetActive(true);
        }

        PlaySound(tightenSound);
        UpdateUI();
    }

    public void ReleaseCar()
    {
        if (gameOver || !tyreInstalled || !wheelTightened)
            return;

        gameOver = true;
        playerWon = true;

        if (releaseButton != null)
        {
            releaseButton.SetActive(false);
        }

        // Spin the car when the player wins
        if (victoryCarSpin != null)
        {
            victoryCarSpin.StartSpinning();
        }

        PlaySound(winSound);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
        {
            timerText.text =
                "TIME: " + timeRemaining.ToString("F1");
        }

        if (statusText == null)
            return;

        if (gameOver)
        {
            if (playerWon)
            {
                statusText.text =
                    "VICTORY!\n\n" +
                    "PIT STOP COMPLETE!\n" +
                    "GREAT JOB!\n\n" +
                    "TIME LEFT: " +
                    timeRemaining.ToString("F1") + "s";
            }
            else
            {
                statusText.text =
                    "TIME UP!\n\n" +
                    "PIT STOP FAILED!\n" +
                    "TRY AGAIN!";
            }

            return;
        }

        statusText.text =
            "F1 PIT STOP\n\n" +
            (tyreInstalled ? "[DONE]" : "[ ]") +
            " Fit replacement tyre\n" +
            (wheelTightened ? "[DONE]" : "[ ]") +
            " Tighten with wheel gun\n\n" +
            (wheelTightened
                ? "PRESS RELEASE BUTTON!"
                : "COMPLETE THE PIT STOP");
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
