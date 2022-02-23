using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionDisplay : MonoBehaviour
{

    private float deltaT = 0.2f;
    private int timeStep = 80;
    private List<float> valueList;

    public float parameter_a = 0f;
    public float parameter_b = 0f;

    public float parameter_a0 = 0f;
    public float parameter_b0 = 0f;

    private Color color_trace1 = new Color (0,1,0, 1f);
    private Color color_trace2 = new Color (0.2f,0.35f,0.2f, 1f);

    public float random_start_value_a;
    public float random_start_value_b;

    public bool game_won = false;

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        random_start_value_a = Random.Range(0f, 6.28f);
        random_start_value_b = Random.Range(0.3f, 1f);
        //List<float> valueList = new List<float>() {5, 98, 56, 45, 30, 22, 14, 10, 15, 13, 12, 11, 37};

        valueList = CreateList(random_start_value_a, random_start_value_b);
        ShowGraph(valueList, color_trace2, 11f);
        valueList = CreateList(parameter_a, parameter_b);
        ShowGraph(valueList, color_trace1, 3f);
    }

    private void Update()
    {
        if (parameter_a0 != parameter_a || parameter_b0 != parameter_b)
        {
            Clear();
            valueList = CreateList(random_start_value_a, random_start_value_b);
            ShowGraph(valueList, color_trace2, 11f);
            valueList = CreateList(parameter_a, parameter_b);
            ShowGraph(valueList, color_trace1, 3f);
        }
        parameter_a0 = parameter_a;
        parameter_b0 = parameter_b;
    }

    private void Clear()
    {
        foreach (Transform child in graphContainer.transform)
        {
            if (child.name != "background"){GameObject.Destroy(child.gameObject);};
        }
    }

    public void Change_Value_a(float button_value)
    {
        if (!game_won) { parameter_a = button_value * 6.28f; }
    }

    public void Change_Value_b(float button_value)
    {
        if (!game_won) { parameter_b = 0.1f + button_value * .9f; }
    }

    private List<float> CreateList(float parameter_a, float parameter_b)
    {
        List<float> valueList = new List<float>() {};
        for (int i = 0; i < timeStep; i++)
        {
            // Version 1
            valueList.Add( 50f + 25f * Mathf.Sin((deltaT*80/timeStep) * i + parameter_a) + parameter_b * 16 * Mathf.Sin(2f * (deltaT * 80 / timeStep) * i));
            // Version 2
            //valueList.Add( 50f + 25f * Mathf.Sin((deltaT * 80f / timeStep) * i + parameter_a) + 16f * Mathf.Sin(2f * (deltaT * 80f / timeStep) * i + 4f * parameter_b));
        }
        return valueList;
    }

    /*private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(0, 0);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }*/
    /*private void ShowGraph(List<float> valueList, Color color, float sizeDelta)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 12f;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = (i + 1) * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition, color, sizeDelta);
            }
            lastCircleGameObject = circleGameObject;
        }
    }
    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB, Color color, float sizeDelta)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, sizeDelta);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(new Vector2(1, 0), dir));
    }*/
    private void ShowGraph(List<float> valueList, Color color, float sizeDelta)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float graphWidth = graphContainer.sizeDelta.x;
        float xSize = graphWidth / timeStep;

        Vector2 lastVectorObject = new Vector2(-100000f,-100000f);
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = (i + 1) * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            Vector2 vectorObject = new Vector2(xPosition, yPosition);
            //GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastVectorObject != new Vector2(-100000f, -100000f))
            {
                CreateDotConnection(lastVectorObject, vectorObject, color, sizeDelta);
            }
            lastVectorObject = vectorObject;
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB, Color color, float sizeDelta)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, sizeDelta);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(new Vector2(1, 0), dir));
    }

    private void Reset()
    {
        random_start_value_a = Random.Range(0f, 6.28f);
        random_start_value_b = Random.Range(0.3f, 1f);

        valueList = CreateList(random_start_value_a, random_start_value_b);
        ShowGraph(valueList, color_trace2, 11f);
        valueList = CreateList(parameter_a, parameter_b);
        ShowGraph(valueList, color_trace1, 3f);

        parameter_a = 0f;
        parameter_b = 0f;
        parameter_a0 = 0f;
        parameter_b0 = 0f;

        game_won = false;

    }
}
