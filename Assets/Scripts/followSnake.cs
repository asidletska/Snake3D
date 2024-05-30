using UnityEngine;
public class followSnake : MonoBehaviour
{
    public Transform snake;
    public Vector3 offset;
    public Vector3 axis;

    // Update is called once per frame
    void Update()
    {
        transform.position = snake.position + offset;
        //transform.rotation = snake.rotation;
        //transform.Rotate(axis);
    }
}
