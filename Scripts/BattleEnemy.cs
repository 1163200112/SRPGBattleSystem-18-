using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : BattleBase {

    private Texture2D battleTex;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBattleTex(string filename)
    {
        this.battleTex = Resources.Load<Texture2D>("Graphics/Battlers/" + filename);
    }
}
