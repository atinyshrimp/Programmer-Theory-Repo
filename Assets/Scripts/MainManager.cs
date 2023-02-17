using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// review the whole saving system
public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public NeedsController needsController;

    private string _petName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("More than one MainManager in the scene");
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Pet pet = LoadPet();
        if (pet != null) Debug.Log(LoadPet().Energy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.GameHourTimer < 0)
        {
            Pet pet = new Pet(needsController.LastEntertained, needsController.LastFed, needsController.LastGainedEnergy, needsController.LastHealthy,
                needsController.Energy, needsController.Fun, needsController.Health, needsController.Hunger);
            SavePet(pet);
        }
    }

    [System.Serializable]
    class SaveData
    {

    }

    void LoadInfo<T>(string name, System.Action<T> callback)
    {
        string path = Application.dataPath + "/Saves/";
        if (File.Exists(path + name + ".json"))
        {
            string loadedJson = File.ReadAllText(path + name + ".json");
            callback(JsonUtility.FromJson<T>(loadedJson));
        }
        else Debug.Log("File doesn't exist");
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;
        LoadInfo<Pet>("pet", (pet) =>
        {
            returnValue = pet;
        });
        return returnValue;
    }

    void SavePet(Pet pet)
    {
        SaveInfo("pet", pet);
    }

    void SaveInfo<SaveData>(string name, SaveData saveData)
    {
        string path = Application.dataPath + "/Saves/";
        string jsonToSave = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + name + ".json", jsonToSave);
    }

}
