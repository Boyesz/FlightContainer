using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSerializer : MonoBehaviour {

    [SerializeField]
    List<GameObject> objects;

    private bool isSaving = false;
    private string fileName = "Coords";
    private Coordinates serializer;

    // Use this for initialization
    void Start () {
        serializer = new Coordinates();

        //We create file if it does not exists.
        if (File.Exists("Assets/Resources/" + fileName + ".json"))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }
#if UNITY_EDITOR
        StreamWriter sre = File.CreateText("Assets/Resources/" + fileName + ".json");
        sre.WriteLine("Coordinates container:");
        sre.Close();
#endif
#if UNITY_STANDALONE
        StreamWriter srs = File.CreateText(fileName + ".json");
        srs.WriteLine("Coordinates container:");
        srs.Close();
#endif

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            if(isSaving == false)
            isSaving = true;
            else
            isSaving = false;  
	}
    void LateUpdate()
    {
        if(isSaving == true)
        {
            Debug.Log("Serialize coorinates");
            foreach (GameObject item in objects)
            {
                serializer.name = item.transform.name;
                serializer.x = item.transform.position.x;
                serializer.y = item.transform.position.y;
                serializer.z = item.transform.position.z;
                serializer.rotX = item.transform.rotation.x;
                serializer.rotY = item.transform.rotation.y;
                serializer.rotZ = item.transform.rotation.z;
                serializer.rotW = item.transform.rotation.w;
                string writeOut = JsonUtility.ToJson(serializer);
#if UNITY_EDITOR
                StreamWriter writerEditor = new StreamWriter("Assets/Resources/" + fileName + ".json", append: true);
                writerEditor.WriteLine(writeOut);
                writerEditor.Close();
#endif
#if UNITY_STANDALONE
                StreamWriter writerStandalone = new StreamWriter(fileName + ".json", append: true);
                writerStandalone.WriteLine(writeOut);
                writerStandalone.Close();
#endif
            }


        }
    }
}
