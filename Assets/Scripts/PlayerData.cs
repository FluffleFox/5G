﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int money;

    public int armorLevel;
    public int heliLevel;
    public int accurateLevel;

    public int currentSceneIndex;

    public PlayerData(int _level, int _money, int _armorLevel, int _heliLevel, int _accurateLevel, int _sceneIndex)
    {
        level = _level;
        money = _money;

        armorLevel = _armorLevel;
        heliLevel = _heliLevel;
        accurateLevel = _accurateLevel;

        currentSceneIndex = _sceneIndex;
    }
}
