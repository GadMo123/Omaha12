using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public delegate void OnClick(GameObject clickedObject); // Delegate for click event
    public OnClick onClick; // Public event to subscribe to

    public static Shader glowShader = Shader.Find("Assets/Shaders/CardSelected.shader"); // Static glowShader

    void Start()
    {
        // Enable collider for click detection (if needed)
        gameObject.GetComponent<Collider>().enabled = true;
    }

    void OnMouseDown() // Or another click detection method like OnMouseOver
    {
        // Call the click event if any functions are subscribed
        onClick?.Invoke(gameObject);

        // Apply glow shader if a listener is subscribed (prevents unnecessary shader assignment)
        if (onClick != null)
        {
            SpotSelectionOnClick(gameObject);
        }
    }

    public static void SpotSelectionOnClick(GameObject clickedObject)
    {
        Renderer renderer = clickedObject.GetComponent<Renderer>();
        if (renderer != null) // Check if renderer exists before applying shader
        {
            renderer.material.shader = glowShader;
        }
    }
}
