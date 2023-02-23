using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


// review the whole saving system
public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    [SerializeField] private NeedsController _needsController;
    [SerializeField] private string _petName = "Kitty";

    private Pet _pet;
    public Pet CurrentPet { get { return _pet; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.GetComponent<MainManager>().enabled = true;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("More than one MainManager in the scene");
            return;
        }

        _needsController = GameObject.Find("Cat").GetComponent<NeedsController>();
    }

    public void GetCatName(string catName)
    {
        _petName = catName;
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1) _needsController = GameObject.Find("Cat").GetComponent<NeedsController>();        
    }

    private void OnApplicationQuit()
    {
        SavePet();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.GameHourTimer < 0)
        {
            _pet = new Pet(_petName, _needsController.Energy, _needsController.Fun, _needsController.Health, _needsController.Hunger);
        }
    }

    [System.Serializable]
    public class Pet
    {
        public string petName;
        public int energy, fun, health, hunger;

        public Pet(string petName, int energy, int fun, int health, int hunger)
        {
            this.petName = petName;
            this.energy = energy;
            this.fun = fun;
            this.health = health;
            this.hunger = hunger;
        }
    }

    public bool LoadPet()
    {
        string path = Application.dataPath + $"/Saves/{_petName}.json";
        bool res = false;
        if (File.Exists(path))
        {
            res = true;

            string json = File.ReadAllText(path);
            _pet = JsonUtility.FromJson<Pet>(json);
        }
        return res;
    }

    public void SavePet()
    {
        Pet toSave = new Pet(_petName, _needsController.Energy, _needsController.Fun, _needsController.Health, _needsController.Hunger);
        string json = JsonUtility.ToJson(toSave);
        string path = Application.dataPath + $"/Saves/{toSave.petName}.json";
        Debug.Log(path);
        File.WriteAllText(path, json);

        // SaveInfo("pet", pet);
    }

    void SaveInfo<SaveData>(string name, SaveData saveData)
    {
        string path = Application.dataPath + "/Saves/";
        string jsonToSave = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + name + ".json", jsonToSave);
    }

}
