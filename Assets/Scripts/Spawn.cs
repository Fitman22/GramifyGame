using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float time;

    private void Start()
    {
       
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(time);
        Vector2 pos = new Vector2(Random.Range(-8,8),6);
       GameObject cubo= Instantiate(obj,pos,transform.rotation);
        Destroy(cubo,10f);
        StartCoroutine(spawn());
    }
}
