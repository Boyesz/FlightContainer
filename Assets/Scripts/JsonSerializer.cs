using System.IO;
using UnityEngine;

public class JsonSerializer : MonoBehaviour {

    [SerializeField]
    GameObject object1;
    GameObject object2;

    private bool isSaving = false;
    private string fileName = "Coords";
    private Cordinates serializer;

    // Use this for initialization
    void Start () {
        serializer = new Cordinates();

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
            serializer.x = object1.transform.position.x;
            serializer.y = object1.transform.position.y;
            serializer.z = object1.transform.position.z;
            string writeOut = JsonUtility.ToJson(serializer);

        }
    }
}
