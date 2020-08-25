public class BasicHit : Hit
{
    public override void GetHit()
    {
        if (DeadRay.tower != null && gameObject.activeSelf)
        {
            StartCoroutine(DIE());
        }
    }
}
