using System.Collections;
using UnityEngine;

public class FrozenEffect : Item
{
    float speed;
    public float defrostTime=1;

    private void Start()
    {
        ResetChance();
    }

    public override void ItemAction()
    {
        base.ItemAction();
        speed = transform.parent.GetComponent<Movment>().movmentSpeed;
        transform.parent.GetComponent<Movment>().movmentSpeed = 0;
        model.transform.localScale = Vector3.one;
    }

    private void Update()
    {
        if (model.activeSelf)
        {
            model.transform.localScale -= Vector3.up * Time.deltaTime/defrostTime;
            if (model.transform.localScale.y <= 0.0f)
            {
                transform.parent.GetComponent<Movment>().movmentSpeed = speed;
                LastFrameAction();
            }
        }
    }

    public override void LastFrameAction()
    {
        base.LastFrameAction();
        if (speed > 0.5f)
        {
            transform.parent.GetComponent<Movment>().movmentSpeed = speed;
        }
        else
        {
            transform.parent.GetComponent<Movment>().movmentSpeed = Random.Range(0.8f, 1.5f);
        }
    }
}
