using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
    public TMP_Text score_;
    // Start is called before the first frame update
    void Start()
    {
        score_ = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score_.text = GameManager.Score.ToString();
    }
}
