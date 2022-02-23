using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementAiguille : MonoBehaviour
{
    [SerializeField]
    private float angle_aiguille;
    [SerializeField]
    private GameObject aiguille;
    [SerializeField]
    private float decroissance = 1f;
    [SerializeField]
    private float croissance = 20f;
    [SerializeField]
    private List<float> boost_list;

    private float angle_limit_inf = 135f;
    private float angle_limit_sup = 170f;

    private float duration_in_right_range = 0f;
    private float duration_in_right_range_required = 150f;

    private Quaternion rotation_aiguille;

    [SerializeField]
    private GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        angle_aiguille = 0;
        rotation_aiguille.eulerAngles = new Vector3(0, 0, angle_aiguille);
        aiguille.transform.rotation = rotation_aiguille;
    }

    // Update is called once per frame
    void Update()
    {
        if (boost_list.Count > 0)
        {
            angle_aiguille += boost_list[0];
            boost_list.RemoveAt(0);
        }
        angle_aiguille -= decroissance;
        angle_aiguille = Mathf.Min(Mathf.Max(angle_aiguille, 0f), 180f);
        rotation_aiguille.eulerAngles = new Vector3(0, 0, -angle_aiguille);
        aiguille.transform.rotation = rotation_aiguille;
    }

    private void FixedUpdate()
    {
        if (angle_aiguille >= angle_limit_inf && angle_aiguille <= angle_limit_sup)
        {
            duration_in_right_range += 1f;
            if (duration_in_right_range >= duration_in_right_range_required)
            {
                decroissance = 0f;
                croissance = 0f;
                text.SetActive(true);
            }
        }
        else
        {
            duration_in_right_range = 0f;
        }
    }

    public void boost()
    {
        boost_list.Add(croissance);
    }
}
