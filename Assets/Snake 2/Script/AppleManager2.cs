using System.Collections.Generic;
using UnityEngine;

public class AppleManager2 : MonoBehaviour
{

    [SerializeField] private GameObject applePrefab;


    public void CreateApple(List<Vector3> emptyCells)
    {
        if (emptyCells.Count == 0)
        {
            return;
        }
        int index = Random.Range(0, emptyCells.Count);
        var appleGo = Instantiate(applePrefab);
        Apple2 apple = appleGo.GetComponent<Apple2>();
        apple.OnCollide += Apple2_OnCollide;
    }

    private void Apple2_OnCollide(Apple2 apple, ObjectType obj)
    {
        if (obj == ObjectType.Segment)
        {
            DestoyApple(apple);
        }
    }

    private void DestoyApple(Apple2 apple)
    {
        apple.OnCollide -= Apple2_OnCollide;
        GameObject.Destroy(apple.gameObject);
    }
    public void Init()
    {
        var apple = FindObjectOfType<Apple2>();
        if (apple != null)
        {
            DestoyApple(apple);
        }
    }
    void Start()
    {

    }
}
