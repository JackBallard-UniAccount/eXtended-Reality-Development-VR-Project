using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    [Header("Numpad Settings")]
    public string Sequence;
    public GameObject Card;
    public TextMeshProUGUI InputDisplayText;
    private string m_CurrentEnteredCode = "";
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(string numPressed)
    {
        m_CurrentEnteredCode += numPressed;
        Debug.Log(m_CurrentEnteredCode);
        InputDisplayText.text = m_CurrentEnteredCode;
        CheckCombination();
    }

    private void CheckCombination()
    {
        if(m_CurrentEnteredCode.Length >= 4)
        {
            if(m_CurrentEnteredCode == Sequence)
            {
                Card.SetActive(true);
            }
            else
            {
                while(timer<200)
                {
                    timer += Time.deltaTime;
                    m_CurrentEnteredCode = "";
                }
                timer = 0;
            }
        }
    }
}
