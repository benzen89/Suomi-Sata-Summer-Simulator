using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class movesToJson : MonoBehaviour {

    MyClass myObject;

    bool listed;
    public string limb;

    void Start () {
        myObject = new MyClass();
        myObject.positions = new List<Vector3>();
        myObject.rotations = new List<Quaternion>();
        myObject.times = new List<float>();

        listed = false;
    }
	
	void Update () {

        if (!listed)
        {
            myObject.date = System.DateTime.Now.ToString();
            myObject.limb = limb;
            myObject.positions = new List<Vector3>();
            myObject.times = new List<float>();
            
            listed = true;
        }
        myObject.positions.Add(this.transform.position);
        myObject.rotations.Add(this.transform.rotation);
        myObject.times.Add(Time.time);
    }

    void OnApplicationQuit()
    {
        SaveMovementData();
        Debug.Log("saved movement data to /TrackedData");
    }

    void SaveMovementData()
    {
        string json = JsonUtility.ToJson(myObject);
        Debug.Log(json);

        //File.WriteAllText(Application.dataPath + "/Player.json", json);

        System.DateTime moment = System.DateTime.Now;
        int year = moment.Year;
        int month = moment.Month;
        int day = moment.Day;
        int hour = moment.Hour;
        int minute = moment.Minute;
        int second = moment.Second;

        File.WriteAllText(Application.dataPath + "/TrackingData/" + year + month + day + hour + minute + second + ".json", json);
    }
}

[System.Serializable]
public class MyClass
{
    public string date;
    public string limb;
    public List<Vector3> positions;
    public List<Quaternion> rotations;
    public List<float> times;
}
