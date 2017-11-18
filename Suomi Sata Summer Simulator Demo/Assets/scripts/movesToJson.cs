using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class movesToJson : MonoBehaviour {

    MyClass myObject;

    bool listed;

    void Start () {
        myObject = new MyClass();
        myObject.positions = new List<Vector3>();

        listed = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!listed)
        {
            myObject.positions = new List<Vector3>();
            listed = true;
        }
        myObject.positions.Add(this.transform.position);

        if (Input.GetButtonDown("Fire1"))
        {
            string json = JsonUtility.ToJson(myObject);
            Debug.Log(json);

            File.WriteAllText(Application.dataPath + "/Player.json", json);
        }
    }
}

[System.Serializable]
public class MyClass
{
    public List<Vector3> positions;
}
