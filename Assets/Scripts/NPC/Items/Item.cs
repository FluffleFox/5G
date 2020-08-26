using UnityEngine;

public class Item : MonoBehaviour
{
    public float chance;

    [SerializeField]
    AnimationCurve chanceOverLevels=null;
    [SerializeField]
    protected GameObject model=null;

    private void Awake()
    {
        ResetChance();
    }

    protected void SetChance()
    {
        chance = chanceOverLevels.Evaluate((float)GeneralGameMenager.instance.data.level);
    }

    protected void ResetChance()
    {
        chance = 0;
    }

    public virtual void ItemAction()
    {
        model.SetActive(true);
    }

    public virtual void ItemHitAction()
    {

    }

    public virtual void LastFrameAction()
    {
        model.SetActive(false);
    }
}
