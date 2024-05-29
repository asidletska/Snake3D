using UnityEngine;

public class Apple2 : MonoBehaviour
{
    public event System.Action<Apple2, ObjectType> OnCollide;

    public void OnTriggerEnter(Collider other)
    {
        OnCollide?.Invoke(this, (ObjectType)other.gameObject.layer);
        
    }
}
