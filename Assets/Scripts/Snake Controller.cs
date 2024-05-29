using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeController : MonoBehaviour
{
    
    public List<Transform> Tails;
    [Range(0,3)]
    public float BonesDistance;
    public GameObject BonePrefab;
    [Range(0, 4)]
    public float Speed;
    private Transform _transform;
    public AppleSpawner AppleSpawnerController;
    public UnityEvent OnEat;
    public GameObject panelRestart;
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        MoveSnake(_transform.position + _transform.forward * Speed );

        float angel = Input.GetAxis("Horizontal") * 4;
        _transform.Rotate(0, angel, 0);
    }
    private void MoveSnake(Vector3 newPosition) 
    { 
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previousPosition = _transform.position;

        foreach (var bone in Tails)
        {
            if((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = previousPosition;
                previousPosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;         
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);
            AppleSpawnerController.SpawnApple();
            if(OnEat != null)
            {
                OnEat.Invoke();
            }
        }
        else if (collision.gameObject.tag == "Fence")
        {
            Time.timeScale = 0f;
            panelRestart.SetActive(true);
        }

    }

}
