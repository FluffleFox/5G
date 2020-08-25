public class ArmoredHit : Hit
{
    int hp = 1;

    public override void GetHit()
    {
        hp -= GeneralGameMenager.instance.data.forceLevel;
        if (hp <= 0 && DeadRay.tower != null && gameObject.activeSelf)
        {
            StartCoroutine(DIE());
        }
    }

    public void SetHP(int value)
    {
        hp = value;
    }
    public void AddHP(int valueToAdd)
    {
        hp += valueToAdd;
    }
}
