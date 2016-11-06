using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {

	// Update is called once per frame
    void Update()
    {
        float tex=0, tey=0;
        lock (ConnectSocket.o)
        {
            tex = GameData.x;
            tey = GameData.y;
        }
        Vector3 te = this.transform.position;
        te.x = tex;
        te.y = tey;
        this.transform.position = te;
	}
}
