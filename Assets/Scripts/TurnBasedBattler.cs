using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedBattler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform duckBattler;
    public AnimationCurve duckAttackCurve;
    public AnimationCurve duckReturnCurve; 
    public float t = 0;
    //implement LERP later
    public float distanceMult = 3;
    public Transform startPos;

    public Button attackButton; 

    void Start()
    {
        duckBattler.position = startPos.position; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InitiateDuckAttack()
    {
        StartCoroutine(DuckAttack());
    }

    IEnumerator DuckAttack()
    {
        duckBattler.position = startPos.position;
        t = 0; 
        while (t < 1)
        {
            t += Time.deltaTime;
            duckBattler.localScale = new Vector2(1 + duckAttackCurve.Evaluate(t), 1 + duckAttackCurve.Evaluate(t));
            duckBattler.position = new Vector2(startPos.position.x + duckAttackCurve.Evaluate(t) * distanceMult, startPos.position.y); 
            yield return null;

        }

        while (t > 0)
        {
            t -= Time.deltaTime * 2f;
            duckBattler.localScale = new Vector2(1 + duckReturnCurve.Evaluate(t), 1 + duckReturnCurve.Evaluate(t));
            duckBattler.position = new Vector2(startPos.position.x + duckReturnCurve.Evaluate(t) * distanceMult, startPos.position.y);
            yield return null;

        }
    }
}
