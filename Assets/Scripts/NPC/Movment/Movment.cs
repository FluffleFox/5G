using UnityEngine;

public class Movment : MonoBehaviour
{
    public float movmentSpeed;
    protected NPC_ControlScript control;
    protected float a;
    private void Awake()
    {
        control = GetComponent<NPC_ControlScript>();
        a = Mathf.Tan(Camera.main.fieldOfView * Mathf.Deg2Rad * 0.5f);
    }
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {

    }

    public virtual void MovmentPrepare()
    {

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
        {
            control.Prepare();
        }
        if (other.tag== "HPCheeck")
        {
            if (control.GetScoreValue()>0)
            {
                ScoreCounter.counter.LostHP();
            }
        }
    }

}
