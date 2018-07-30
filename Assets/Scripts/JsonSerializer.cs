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
            string writeOut = null;
            Debug.Log("Serialize coorinates");
            for(int i = 1; i <= objects.Count; i++)
            {
                if(i == 1)
                {
                    writeOut += "{ "
                   + "x" + i + ":" + objects[i - 1].transform.position.x.ToString("0.0000000000")
                   + ", y" + i + ":" + objects[i - 1].transform.position.y.ToString("0.0000000000")
                   + ", z" + i + ":" + objects[i - 1].transform.position.z.ToString("0.0000000000")
                   + ", rotX" + i + ":" + objects[i - 1].transform.rotation.x.ToString("0.0000000000")
                   + ", rotY" + i + ":" + objects[i - 1].transform.rotation.y.ToString("0.0000000000")
                   + ", rotZ" + i + ":" + objects[i - 1].transform.rotation.z.ToString("0.0000000000")
                   + ", rotW" + i + ":" + objects[i - 1].transform.rotation.w.ToString("0.0000000000")
                   + ", ";
                    continue;
                }
                if (i == objects.Count)
                {
                    writeOut += 
                  "x" + i + ":" + objects[i - 1].transform.position.x.ToString("0.0000000000")
                  + ", y" + i + ":" + objects[i - 1].transform.position.y.ToString("0.0000000000")
                  + ", z" + i + ":" + objects[i - 1].transform.position.z.ToString("0.0000000000")
                  + ", rotX" + i + ":" + objects[i - 1].transform.rotation.x.ToString("0.0000000000")
                  + ", rotY" + i + ":" + objects[i - 1].transform.rotation.y.ToString("0.0000000000")
                  + ", rotZ" + i + ":" + objects[i - 1].transform.rotation.z.ToString("0.0000000000")
                  + ", rotW" + i + ":" + objects[i - 1].transform.rotation.w.ToString("0.0000000000")
                  + " }";
                    continue;
                }
                writeOut +=
                "x" + i + ":" + objects[i - 1].transform.position.x.ToString("0.0000000000")
                + ", y" + i + ":" + objects[i - 1].transform.position.y.ToString("0.0000000000")
                + ", z" + i + ":" + objects[i - 1].transform.position.z.ToString("0.0000000000")
                + ", rotX" + i + ":" + objects[i - 1].transform.rotation.x.ToString("0.0000000000")
                + ", rotY" + i + ":" + objects[i - 1].transform.rotation.y.ToString("0.0000000000")
                + ", rotZ" + i + ":" + objects[i - 1].transform.rotation.z.ToString("0.0000000000")
                + ", rotW" + i + ":" + objects[i - 1].transform.rotation.w.ToString("0.0000000000")
                + ", ";
            }
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
