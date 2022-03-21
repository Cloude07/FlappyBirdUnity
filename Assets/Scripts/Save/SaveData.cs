using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int IntegerSave;
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", IntegerSave);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            IntegerSave = PlayerPrefs.GetInt("SavedInteger");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteAll();
        IntegerSave = 0;

        Debug.Log("Data reset complete");
    }
}
