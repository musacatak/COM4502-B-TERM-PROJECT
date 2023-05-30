using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isGameEnded = false;

    public GameObject completeLevelUI;
    public TMPro.TextMeshProUGUI completeLevelGemTMP;
    public TMPro.TextMeshProUGUI completeLevelTMP;
    public GameObject failLevelUI;
    public GameObject mainScreenUI;
    public GameObject progressBarUI;
    public GameObject sliderUI;
    public AnimationController animControl;

    public TMPro.TextMeshProUGUI gemCounterTMP;

    public GameObject player;

    public TMPro.TextMeshProUGUI[] levelTxt;
    public TMPro.TextMeshProUGUI progressBarTMP;

    int currentGemCounter = 0;
    int currentMultiplier = 1;
    //ADS
    bool doubleReward = false;
    bool skipRequest = false;
    bool doubleRewardRequest = false;

    int totalGemCounter = 0;

    bool isLevelFinished = false;
    bool isLevelCompleted = false;

    int currentLevel;

    private void Awake()
    {
        totalGemCounter = GameInfo.totalGems;
        gemCounterTMP.SetText(totalGemCounter + "");
        currentLevel = GameInfo.level + 1;
        progressBarTMP.SetText(currentLevel + "");
        if (currentLevel % 5 == 1)
        {
            levelTxt[0].SetText(currentLevel + "");
            levelTxt[1].SetText((currentLevel + 1) + "");
            levelTxt[2].SetText((currentLevel + 2) + "");
            levelTxt[3].SetText((currentLevel + 3) + "");
            levelTxt[4].SetText((currentLevel + 4) + "");
        }
        else if (currentLevel % 5 == 2)
        {
            levelTxt[0].SetText((currentLevel - 1) + "");
            levelTxt[1].SetText(currentLevel + "");
            levelTxt[2].SetText((currentLevel + 1) + "");
            levelTxt[3].SetText((currentLevel + 2) + "");
            levelTxt[4].SetText((currentLevel + 3) + "");
        }
        else if (currentLevel % 5 == 3)
        {
            levelTxt[0].SetText((currentLevel - 2) + "");
            levelTxt[1].SetText((currentLevel - 1) + "");
            levelTxt[2].SetText(currentLevel + "");
            levelTxt[3].SetText((currentLevel + 1) + "");
            levelTxt[4].SetText((currentLevel + 2) + "");
        }
        else if (currentLevel % 5 == 4)
        {
            levelTxt[0].SetText((currentLevel - 3) + "");
            levelTxt[1].SetText((currentLevel - 2) + "");
            levelTxt[2].SetText((currentLevel - 1) + "");
            levelTxt[3].SetText(currentLevel + "");
            levelTxt[4].SetText((currentLevel + 1) + "");
        }
        else
        {
            levelTxt[0].SetText((currentLevel - 4) + "");
            levelTxt[1].SetText((currentLevel - 3) + "");
            levelTxt[2].SetText((currentLevel - 2) + "");
            levelTxt[3].SetText((currentLevel - 1) + "");
            levelTxt[4].SetText(currentLevel + "");
        }
    }

    public void StopLevel()
    {
        if (isLevelFinished)
        {
            animControl.Dance();
            CompleteLevel(player.GetComponent<CubeHandler>().GetMultiplier());
        }
        else if (!isGameEnded && !isLevelFinished)
        {
            isGameEnded = true;
            DisablePlayerInput();
            failLevelUI.SetActive(true);
            animControl.Death();
            Debug.Log("GAME OVER!");
        }
    }

    public void CompleteLevel(int multiplier)
    {
        if (!isLevelCompleted)
        {
            doubleReward = false;
            currentMultiplier = multiplier;
            isLevelCompleted = true;
            Debug.Log("Complete Level!");
            DisablePlayerInput();

            completeLevelTMP.SetText("GREAT!\n" + multiplier + "X");
            completeLevelGemTMP.SetText(currentGemCounter * multiplier + "");
            completeLevelUI.SetActive(true);
        }
    }

    public void DoubleGem()
    {
        if (!doubleReward)
        {
            currentGemCounter *= 2;
            completeLevelGemTMP.SetText(currentGemCounter * currentMultiplier + "");
            doubleReward = true;
        }
    }

    public void StartLevel()
    {
        Debug.Log("Level Started!");
        sliderUI.SetActive(false);
        mainScreenUI.SetActive(false);
        progressBarUI.SetActive(true);
        EnablePlayerInput();
        currentGemCounter = 0;
        currentMultiplier = 1;
        skipRequest = false;
        doubleRewardRequest = false;
        doubleReward = false;
    }

    public void SkipLevel()
    {
        if (!skipRequest)
        {
            skipRequest = true;
            AdsManager.Instance.ShowRewardedAd();
            GameObject.Find("ReviveButton").GetComponent<Button>().interactable = false;
        }
    }

    public void DoubleRewardButton()
    {
        if (!doubleRewardRequest)
        {
            doubleRewardRequest = true;
            AdsManager.Instance.ShowRewardedAd();
            GameObject.Find("DoubleGemButton").GetComponent<Button>().interactable = false;
        }
    }

    public void AdsResponse()
    {
        if (skipRequest)
        {
            LoadNextLevel();
        }
        else if (doubleRewardRequest)
        {
            DoubleGem();
        }
    }

    public void RestartButton()
    {
        Invoke("Restart", 1f);
    }

    public void NextButton()
    {
        totalGemCounter += (currentGemCounter * currentMultiplier);
        GameInfo.totalGems = totalGemCounter;
        AdsManager.Instance.ShowInterstitialAd();
        Invoke("LoadNextLevel", 1f);
    }

    public void SwipeToPlayButton()
    {
        StartLevel();
    }

    void Restart()
    {
        AdsManager.Instance.ShowInterstitialAd();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        GameInfo.level++;
        if (currentLevel % 5 != 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//loads next scene on the build order
        else
            SceneManager.LoadScene(0);//loads next scene on the build order
    }

    public void TakeGem()
    {
        currentGemCounter++;
        gemCounterTMP.SetText(totalGemCounter + currentGemCounter + "");
    }

    public void LevelFinished()
    {
        isLevelFinished = true;
    }
    void DisablePlayerInput()
    {
        player.GetComponent<SwerveInputSystem>().DisableSwerveInput();
        player.GetComponent<SwerveMovement>().DisableSwerveMove();
    }

    void EnablePlayerInput()
    {
        player.GetComponent<SwerveInputSystem>().EnableSwerveInput();
        player.GetComponent<SwerveMovement>().EnableSwerveMove();
    }


}
