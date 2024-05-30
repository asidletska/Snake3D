using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private new BoxCollider collider;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        { 
            transform.position = value;
        }
    }
    public Vector3 Direction { get; set; }
    
    public Vector3 Collider
    {
        get
        {
            return transform.TransformPoint(collider.center);
        }

        set
        {
            collider.center = transform.InverseTransformPoint(value);
        }
    }

    void Start()
    {
        
    }


}
