using UnityEngine;

public class Object : MonoBehaviour
{
    protected SpriteRenderer sr; // Protected so derived classes can access it

    protected virtual void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer not found on " + gameObject.name);
        }
    }

    protected virtual void Update()
    {
        SetSortingOrder(); // Call in Update to continuously update sorting order
    }

    protected virtual void SetSortingOrder()
    {
        if (sr != null)
        {
            sr.sortingOrder = (int)(-transform.position.y * 100); // Multiply for precision
            // Debug.Log($"{gameObject.name} sorting order: {sr.sortingOrder}");
        }
    }
}