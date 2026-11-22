
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PitStopManager : MonoBehaviour
{
    public float startingTime = 60f;

    [Header("Game Objects")]
    public GameObject releaseButton;

    [Header("UI")]
    public TMP_Text timerText;
    public TMP_Text statusText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip installSound;
    public AudioClip tightenSound;
    public AudioClip winSound;

    private bool tyreInstalled;
    private bool wheelTightened;
    private bool gameOver;
    private float timeRemaining;

    void Start()
    {
        timeRemaining = startingTime;
        releaseButton.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        if (gameOver)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            gameOver = true;
            statusText.text = "TIME UP! PIT STOP FAILED!";
            releaseButton.SetActive(false);
        }

        UpdateUI();
    }

    public void InstallTyre()
    {
        if (gameOver) return;

        tyreInstalled = true;
        PlaySound(installSound);
        UpdateUI();
    }

    public void RemoveTyre()
    {
        if (gameOver) return;

        tyreInstalled = false;
        wheelTightened = false;
        releaseButton.SetActive(false);
        UpdateUI();
    }

    public void TightenWheel()
    {
        if (gameOver || !tyreInstalled || wheelTightened)
            return;

        wheelTightened = true;
        releaseButton.SetActive(true);
        PlaySound(tightenSound);
        UpdateUI();
    }

    public void ReleaseCar()
    {
        if (gameOver || !tyreInstalled || !wheelTightened)
            return;

        gameOver = true;
        releaseButton.SetActive(false);
        PlaySound(winSound);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "TIME: " + timeRemaining.ToString("F1");

        if (statusText == null)
            return;

        if (gameOver)
        {
            statusText.text =
                timeRemaining > 0
                ? "PIT STOP COMPLETE!"
                : "TIME UP! TRY AGAIN!";
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
            audioSource.PlayOneShot(clip);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
