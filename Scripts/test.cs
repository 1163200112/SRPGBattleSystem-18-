using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public Texture2D texture2D;
    private Sprite sprite;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0.0f, 0.0f, -1.0f);
        sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, 200, 200), new Vector2(0.5f, 0.5f));

    }


    // Use this for initialization
    void Start () {
        sr.sprite = sprite;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
