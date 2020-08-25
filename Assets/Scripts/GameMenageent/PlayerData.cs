[System.Serializable]
public class PlayerData
{
    public int level;
    public int experience;
    public int money;

    public int armorLevel;
    public int forceLevel;
    public int accurateLevel;

    public PlayerData(int _level, int _experience, int _money, int _armorLevel, int _forceLevel, int _accurateLevel)
    {
        level = _level;
        experience = _experience;
        money = _money;

        armorLevel = _armorLevel;
        forceLevel = _forceLevel;
        accurateLevel = _accurateLevel;
    }
}
