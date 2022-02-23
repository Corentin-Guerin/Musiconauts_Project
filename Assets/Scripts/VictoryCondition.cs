using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryCondition : MonoBehaviour
{
    private float a;
    private float b;
    private FunctionDisplay child;
    public Text text;
    private Scrollbar scrollbar;

    void Start()
    {
        child = transform.Find("WindowGraph").GetComponent<FunctionDisplay>();
        text = transform.Find("Text").GetComponent<Text>();
        scrollbar = transform.Find("Scrollbar").GetComponent<Scrollbar>();

        text.enabled = false;
    }

    void Update()
    {
        if (!child.game_won)
        {
            if (Mathf.Abs(child.parameter_a - child.random_start_value_a) / 6.28f + Mathf.Abs(child.parameter_b - child.random_start_value_b) < 0.01f)
            {
                text.enabled = true;
                child.game_won = true;
                scrollbar.enabled = false;
            }
        }
    }

    private void Reset()
    {
        child.game_won = false;
        text.enabled = false;
        scrollbar.enabled = true;
    }
}
