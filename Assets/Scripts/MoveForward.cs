
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
