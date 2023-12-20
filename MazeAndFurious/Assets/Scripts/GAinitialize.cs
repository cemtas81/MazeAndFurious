using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GAinitialize : MonoBehaviour
{

    private void Awake()
    {
        GameAnalytics.Initialize();
    }

    public void LevelComplete(int level, int sure)
    {
        level = PlayerPrefs.GetInt("lastLevel");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString() , sure);
    }

    public void LevelFail(int level)
    {
        level = PlayerPrefs.GetInt("lastLevel");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
    }

    public void LevelAnaliz(float levelSave,float sure)
    {
        GameAnalytics.NewDesignEvent("levelComplete:level", levelSave);
        GameAnalytics.NewDesignEvent("levelComplete:level:sure", sure);
    }

    public void LevelDiamond(int level, int diamond)
    {
        level = PlayerPrefs.GetInt("lastLevel");
        diamond = PlayerPrefs.GetInt("totalGem");
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString(), diamond);
    }
}
