using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionRythm : MonoBehaviour
{
    public int numberOfCircles;
    //public List<Cible> listCibles = new List<Cible>();
    public Sprite sprite_ring;
    public float time = 0f;
    public float reflex_time = 10f;

    public List<Button> listButtons = new List<Button>();
    public int numberOfButtons;
    public int numberOfColumns;
    private float widthInPixels = 1.2f;
    private float heightInPixels = 1.2f;
    private int numberOfSwitches = 6;
    private float min_diff_timing = 0.5f;
    private float random_diff_timing = 0.7f;
    private float epsilon_input = 0.2f;

    //private GameManager gm;

    [SerializeField]
    private GameObject go;

    private float global_timing = 0f;

    /*public class Cible
    {
        public Vector2 position;
        public GameObject object_target;
        public GameObject object_moving;
        public float starting_time;
        public float lerp_value;
        public bool isActive;

        public Cible(Vector2 _position, float _starting_time, float _lerp_value, bool _isActive, GameObject _object_target, GameObject _object_moving)
        {
            position = _position; starting_time = _starting_time; lerp_value = _lerp_value; isActive = _isActive; object_target = _object_target; object_moving = _object_moving;
        }

    }*/

    [System.Serializable]
    public class Button
    {
        public int index;
        public Vector2 position;
        public GameObject clickable_button;
        public GameObject effect;
        public bool isActive;
        public float switch_timings;
        public bool isSwitching;
        public float lerp_value;

        public Button(int _index, Vector2 _position, GameObject _clickable_button, GameObject _effect, bool _isActive, float _switch_timings)
        {
            index = _index; position = _position; clickable_button = _clickable_button; effect = _effect; isActive = _isActive; switch_timings = _switch_timings; lerp_value = 0f; isSwitching = false;
        }
    }

    private void Awake()
    {
        sprite_ring = Resources.Load<Sprite>("Sprites/sprite_ring");


    }

    private void Start()
    {
        numberOfButtons = 9;
        numberOfColumns = 3;
        for(int i = 0; i < numberOfButtons; i++)
        {
            float xPos = -1.2f + widthInPixels * (i % numberOfColumns);
            float yPos = -1f - heightInPixels * (i / numberOfColumns);

            GameObject clickable_button = new GameObject("button"+i);
            SpriteRenderer renderer_cb = clickable_button.AddComponent<SpriteRenderer>();
            //BoxCollider2D box_collider_cb = clickable_button.AddComponent<BoxCollider2D>();
            Component comp_boxcollider2d = go.GetComponent<BoxCollider2D>();
            CopyComponent(comp_boxcollider2d, clickable_button);
            Component comp_onclick = go.GetComponent<OnClick>();
            CopyComponent(comp_onclick, clickable_button);



            /*int x = i;
            clickable_button.onClick.AddListener(delegate { ChangeVictoryValue(x); });*/

            //OnClick onclick = clickable_button.AddComponent<OnClick>();
            renderer_cb.sprite = sprite_ring;

            GameObject effect = new GameObject("effect"+i);
            SpriteRenderer renderer_e = effect.AddComponent<SpriteRenderer>();
            renderer_e.sprite = sprite_ring;

            int rand = Random.Range(0, 2);
            bool isActive = rand == 0 ? true : false ;

            Button button = new Button(i, new Vector2(xPos, yPos), clickable_button, effect, isActive, -1f);
            listButtons.Add(button);
        }
        for (int i = 0; i < numberOfSwitches; i++)
        {
            global_timing += min_diff_timing + Random.Range(0f, 1f) * random_diff_timing;
            //Debug.Log(global_timing);
            bool button_not_found = true;
            while (button_not_found)
            {
                int rand_button = Random.Range(0, numberOfButtons);
                if (listButtons[rand_button].switch_timings < 0)
                {
                    button_not_found = false;
                    listButtons[rand_button].switch_timings = global_timing;
                    listButtons[rand_button].isSwitching = true;
                }
            }
        }
        foreach (Button button in listButtons)
        {
            SpriteRenderer sp = button.effect.GetComponent<SpriteRenderer>();
            sp.color = new Color(1f, 1f, 1f, 0f);
            Transform tr1 = button.clickable_button.transform;
            tr1.position = new Vector3(button.position.x, button.position.y, 0);
            tr1.localScale = new Vector3(0.08f, 0.08f, 1f);
            Transform tr2 = button.effect.transform;
            tr2.position = new Vector3(button.position.x, button.position.y, 0);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;

        foreach (Button button in listButtons)
        {
            if (button.isSwitching && time >= button.switch_timings)
            {
                button.lerp_value = (time - button.switch_timings) / reflex_time;
                //cible.object_moving.transform.localScale = new Vector3(1f - cible.lerp_value, 1f - cible.lerp_value, 1f);
                button.effect.transform.localScale = new Vector3(Mathf.Lerp(1f, 0.08f, button.lerp_value), Mathf.Lerp(1f, 0.08f, button.lerp_value), 1f);
                button.effect.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, button.lerp_value));
            }
            if (button.isSwitching && button.lerp_value > 1f)
            {
                //Debug.Log("TOP "+ ((time - button.switch_timings) - reflex_time));
                button.isSwitching = false;
                button.isActive = button.isActive ? false : true;
            }
        }
            /*if (button.isActive && time >= button.starting_time)
            {
                button.lerp_value = (time - button.starting_time) / reflex_time;
                //cible.object_moving.transform.localScale = new Vector3(1f - cible.lerp_value, 1f - cible.lerp_value, 1f);
                button.object_moving.transform.localScale = new Vector3(Mathf.Lerp(1f, 0.08f, button.lerp_value), Mathf.Lerp(1f, 0.08f, button.lerp_value), 1f);
                button.object_moving.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, button.lerp_value));
            }
            if (button.lerp_value > 1f)
            {
                button.isActive = false;
            }*/
    }

    /*private void Start()
    {
        numberOfCircles = Random.Range(3, 5);
        for( int i = 0; i < numberOfCircles; i++)
        {
            //float xPos = .1f * (Random.Range(0f, Screen.width) * 0.8f + Screen.width * 0.1f);
            //float yPos = .1f * (Random.Range(0f, Screen.height) * 0.8f + Screen.height * 0.1f);
            float xPos = Random.Range(-1.7f, 1.7f);
            float yPos = Random.Range(-3f, 3f);
            float timing = Random.Range(2f, 5f);

            Debug.Log(xPos);
            Debug.Log(yPos);

            GameObject o_t = new GameObject("ring");
            SpriteRenderer renderer_o_t = o_t.AddComponent<SpriteRenderer>();
            BoxCollider2D box_collider_o_t = o_t.AddComponent<BoxCollider2D>();
            OnClick onclick = o_t.AddComponent<OnClick>();
            //._onClick.AddListener()
            renderer_o_t.sprite = sprite_ring;
            GameObject o_m = new GameObject("ring");
            SpriteRenderer renderer_om = o_m.AddComponent<SpriteRenderer>();
            renderer_om.sprite = sprite_ring;

            Cible cible = new Cible(new Vector2(xPos, yPos), timing, 0f, true, o_t, o_m);
            //cible.object_moving. =
            listCibles.Add(cible);
        }
        foreach (Cible cible in listCibles)
        {
            SpriteRenderer sp = cible.object_moving.GetComponent<SpriteRenderer>();
            sp.color = new Color(1f, 1f, 1f, 0f);
            Transform tr1 = cible.object_target.transform;
            tr1.position = new Vector3(cible.position.x,cible.position.y,0);
            tr1.localScale = new Vector3(0.08f, 0.08f, 1f);
            Transform tr2 = cible.object_moving.transform;
            tr2.position = new Vector3(cible.position.x, cible.position.y, 0);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        foreach (Cible cible in listCibles)
        {
            if(cible.isActive && time >= cible.starting_time)
            {
                cible.lerp_value = (time - cible.starting_time)/reflex_time;
                //cible.object_moving.transform.localScale = new Vector3(1f - cible.lerp_value, 1f - cible.lerp_value, 1f);
                cible.object_moving.transform.localScale = new Vector3(Mathf.Lerp(1f, 0.08f, cible.lerp_value), Mathf.Lerp(1f, 0.08f, cible.lerp_value),1f);
                cible.object_moving.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, cible.lerp_value));
            }
            if (cible.lerp_value > 1f)
            {
                cible.isActive = false;
            }
        }
    }*/

    Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }

    public void ChangeVictoryValue(int i)
    {
        float diff = Mathf.Abs((time - listButtons[i].switch_timings) - reflex_time);
        if (diff <= epsilon_input)
        {
            Debug.Log("Oui "+ i +" --- " + diff);
        }
        else
        {
            Debug.Log("Non " + i + " --- " + diff);
        }
        /*
        foreach (Button button in listButtons)
        {
            if ((time - button.switch_timings + reflex_time) <= epsilon_input)
            {
                Debug.Log("Oui");
            }
            else
            {
                Debug.Log("Non");
            }
        }*/
    }
}
