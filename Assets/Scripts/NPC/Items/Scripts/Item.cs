using UnityEngine;

public class Item : MonoBehaviour
{
    public float chance;

    [SerializeField]
    AnimationCurve chanceOverLevels=null;
    [SerializeField]
    protected GameObject model=null;

    private void OnEnable()
    {
        chance = chanceOverLevels.Evaluate((float)GeneralGameMenager.instance.data.level);
        model.SetActive(true);
    }

    private void OnDisable()
    {
        model.SetActive(false);
    }

    public virtual void ItemAction()
    {

    }

    public virtual void LastFrameAction()
    {

    }
}
