using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ObjectType
{
    None,
    Segment = 8,
    Apple = 9,
    Block = 10
}
public class Snake2 : MonoBehaviour
{
    [SerializeField] private GameObject segmentPrefab;
    [SerializeField] private LayerMask collideMask;

    public List<Segment> segments;

    private Vector3 direction;

    private Vector3 tempDirection;

    public IReadOnlyList<Segment> Segments
    {
        get
        {
            return segments;
        }

    }

    private void Clear()
    {
        if (segments != null)
        {
            for (int i = 0; i < segments.Count; i++)
            {
                GameObject.Destroy(segments[i].gameObject);
            }
        }
    }

    public void AddSegment(Vector3 pos)
    {
        var segmentGo = Instantiate(segmentPrefab, pos, Quaternion.identity);
        segments.Add(segmentGo.GetComponent<Segment>());

    }
    public void AddSegment()
    {
        Vector3 pos = segments.Last().Position - segments.Last().Direction;
        AddSegment(pos);        
    }

    public void Init(Vector3 headPos)
    {
        direction = Vector3.forward;
        tempDirection = direction;
        Clear();
        AddSegment(headPos);
    }

    public void Move()
    {
        direction = tempDirection;

        for (int i = segments.Count - 1; i >= 1; i--)
        {
            segments[i].Direction = segments[i - 1].Direction;
            segments[i].Position = segments[i - 1].Position;
        }
        segments[0].Direction = direction;
        segments[0].Position += direction;
    }

    public ObjectType CheckCollide()
    {
        ObjectType objType = ObjectType.None;
        for (int i = segments.Count - 1; i >= 1; i--)
        {
            segments[i].Collider = segments[i - 1].Collider;
        }
        var ray = new Ray(segments[0].Position, tempDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1f, collideMask))
        {
            objType = (ObjectType)hit.collider.gameObject.layer;
        }
        for (int i = 0; i < segments.Count; i++)
        {
            segments[i].Collider = segments[i].Position;
        }
        return objType;
    }
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (direction != Vector3.right)
            {
                tempDirection = Vector3.left;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (direction != Vector3.left)
            {
                tempDirection = Vector3.right;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (direction != Vector3.back)
            {
                tempDirection = Vector3.forward;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (direction != Vector3.forward)
            {
                tempDirection = Vector3.back;
            }
        }
    }
}

