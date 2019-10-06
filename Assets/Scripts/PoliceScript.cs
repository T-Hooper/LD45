using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform startPos;
    private Transform currentTarget;
    private bool waited = true;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = target;
        transform.position = startPos.position;

        StartCoroutine(move1());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
        
        
    }

    IEnumerator move1()
    {
        Vector3 characterScale = transform.localScale;
        yield return new WaitUntil(() => (transform.position.x >= target.position.x) && waited);
        waited = false;
        currentTarget = startPos;
        characterScale.x = -characterScale.x;
        transform.localScale = characterScale;
        StartCoroutine(ready());
        StartCoroutine(move2());
    }
    IEnumerator move2()
    {
        Vector3 characterScale = transform.localScale;
        yield return new WaitUntil(() => (transform.position.x <= startPos.position.x ) && waited);
        waited = false;
        currentTarget = target;
        characterScale.x = -characterScale.x;
        transform.localScale = characterScale;
        StartCoroutine(ready());
        StartCoroutine(move1());
    }
    IEnumerator ready()
    {
        yield return new WaitForSeconds(0.5f);
        waited = true;
    }

}
