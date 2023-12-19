using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    public int materialIndex = 1;

    void Start()
    {
        materialIndex = Mathf.Clamp(materialIndex, 0, GetComponent<Renderer>().materials.Length - 1);
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        Material[] materials = GetComponent<Renderer>().materials;

        // change CSTIC material offset so the banner rotates
        if (materialIndex >= 0 && materialIndex < materials.Length)
        {
            materials[materialIndex].mainTextureOffset = new Vector2(offset, 0f);
        }
    }
}
