using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOutLinners : MonoBehaviour
{
    [SerializeField] Text tx;
    public void AsignText(string text)
    {
        tx.text = text;
        GetComponent<Text>().text = text;
    }
}
