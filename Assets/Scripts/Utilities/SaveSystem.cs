using UnityEngine;
using System.IO;
using MiseEnPlace.Data;

namespace MiseEnPlace.Utilities
{
    public static class SaveSystem
    {
        private static string _filePath => Path.Combine(Application.persistentDataPath, "gamestate.json");

        public static void Save(GameState state)
        {
            string json = JsonUtility.ToJson(state, true);
            File.WriteAllText(_filePath, json);
            Debug.Log("GameState saved to " + _filePath);
        }

        public static GameState Load()
        {
            if (!File.Exists(_filePath))
            {
                Debug.Log("No save file found, creating new GameState.");
                return new GameState();
            }
            string json = File.ReadAllText(_filePath);
            return JsonUtility.FromJson<GameState>(json);
        }
    }
}
