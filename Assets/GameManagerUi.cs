using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerUi : MonoBehaviour
{
    public Text ClicksTotalText;
    float TotalClicks;

    public GameObject dollar;
    public AudioSource coinSound;
    public AudioSource egeFitness;
    public Animation doorAnim;

    public Canvas canvasFinish;
    bool finishControl = false;

    bool hasUpgrade;
    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;

    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
        canvasFinish.GetComponent<Canvas>().enabled = false;
    }
    public void KeyClick()
    {
        if (TotalClicks >= 10000)
        {
            doorAnim.Play();
            egeFitness.Play();
            finishControl = true;
        }
    }
    IEnumerator AddApple()
    {
        if (finishControl == true)
        {
            yield return new WaitForSeconds(5.0f);
            canvasFinish.GetComponent<Canvas>().enabled = true;
        }
    }
    public void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");
        coinSound.Play();
        GameObject clone = (GameObject)Instantiate(dollar, transform.position, Quaternion.identity);
        Destroy(clone, 1.0f);
    }
    public void AutoClickUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= minimumClicksToUnlockUpgrade)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade;
            hasUpgrade = true;
        }
    }

    private void Update()
    {
        if (hasUpgrade)
        {
            TotalClicks += autoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
        }
        StartCoroutine(AddApple());
    }

    public void CheatClick()
    {
        TotalClicks += 10000;
        ClicksTotalText.text = TotalClicks.ToString("0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
