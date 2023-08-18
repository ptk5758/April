using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    EASY, NORMAL, EXPERT, HARD
}

public enum GameLevelOption
{
    ITEM
}

public class LevelManager
{
    public static GameLevel gameLevel;
    private static Dictionary<GameLevelOption, int[]> dictionary;
    public static int GetGameLevelOptionData(GameLevelOption option)
    {        
        return dictionary[option][(int)gameLevel];
    }

    public LevelManager()
    {
        /*InitializeGameLevel();*/
        InitializeGameLevelOptionData();
    }

    /// <summary>
    /// 사용안함
    /// </summary>
    private void InitializeGameLevel()
    {
        int gameLevelValue = PlayerPrefs.GetInt("GameLevel");
        SetGameLevel(gameLevelValue);
    }

    private void InitializeGameLevelOptionData()
    {
        dictionary = new Dictionary<GameLevelOption, int[]>();
        dictionary.Add(GameLevelOption.ITEM, new int[] { 8, 5, 3, 1 });
    }
    public static void SetGameLevel(int value)
    {
        switch (value)
        {
            case 0:
                gameLevel = GameLevel.EASY;
                break;
            case 1:
                gameLevel = GameLevel.NORMAL;
                break;
            case 2:
                gameLevel = GameLevel.EXPERT;
                break;
            case 3:
                gameLevel = GameLevel.HARD;
                break;
        }
        Debug.Log(gameLevel);
    }
}
