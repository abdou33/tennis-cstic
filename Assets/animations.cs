using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    public int materialIndex = 1; // Adjust the material index as needed

    void Start()
    {
        // Ensure that the material index is within bounds
        materialIndex = Mathf.Clamp(materialIndex, 0, GetComponent<Renderer>().materials.Length - 1);
    }

    void Update()
    {
        // Calculate the new offset based on time and speed
        float offset = Time.time * scrollSpeed;

        // Get the materials array from the renderer
        Material[] materials = GetComponent<Renderer>().materials;

        // Check if the specified material index is within bounds
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            // Set the offset on the specified material
            materials[materialIndex].mainTextureOffset = new Vector2(offset, 0f);
        }
    }
}
