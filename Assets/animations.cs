using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

    public bool on = true;

    private float scrollSpeed;
    private float offset;
    
    private Material _material;

    void Awake () {
    
    	_material = GetComponent<Renderer>().material;

       if (on) {

         TurnOn ();

       } else {

         TurnOff ();

       }

    }

    void Update () {

		float rate = scrollSpeed * Time.deltaTime;
		
		if (on && offset <= 0.5f) {
			offset = Mathf.Min(0.5f, offset + rate);
			_material.mainTextureOffset = new Vector2 (offset, 0);
		}
		else if (!on && offset > 0.0f) {
			offset = Mathf.Max(0.0f, offset - rate);
			_material.mainTextureOffset = new Vector2 (offset, 0);
		}

    }

    public void TurnOn () {

       on = true;
       offset = 0.0F;
       scrollSpeed = 0.3F;
       _material.mainTextureOffset = new Vector2 (0.0F, 0.5F);
       GetComponent<Collider>().enabled = true;

    }

    public void TurnOff () {

       on = false;
       offset = 0.5F;
       scrollSpeed = 0.002F;
       _material.mainTextureOffset = new Vector2 (0.5F, 0.5F);
       GetComponent<Collider>().enabled = false;

    }

}