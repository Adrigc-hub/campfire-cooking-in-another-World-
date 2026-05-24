using UnityEngine;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;
    
    [Header("Configuración del Mundo Abierto")]
    public GameObject playerVR;
    public List<Transform> cityLocations = new List<Transform>();
    
    // Diccionario para registrar qué hay en cada zona del mapa
    private Dictionary<Vector3, string> mapZones = new Dictionary<Vector3, string>();
    private Vector3 rentedRoomPosition = new Vector3(0, 5, 20); // Coordenadas del cuarto de renta

    void Awake()
    {
        Instance = this;
        GenerateOpenWorld();
    }

    void GenerateOpenWorld()
    {
        Debug.Log("--- GENERANDO MUNDO ABIERTO DE MUKOUDA ---");
        
        // 1. Generar Ciudad Inicial (Fier)
        CreateCity("Ciudad de Fier", new Vector3(0, 0, 0));
        
        // 2. Generar Ciudad de los Gremio de Aventureros (Karelina)
        CreateCity("Ciudad de Karelina", new Vector3(500, 0, 500));
    }

    void CreateCity(string cityName, Vector3 position)
    {
        Debug.Log($"Generando {cityName} en coordenadas: {position}");
        
        // Generar Casas comunes
        for (int i = 0; i < 5; i++)
        {
            Vector3 housePos = position + new Vector3(i * 15, 0, 10);
            mapZones.Add(housePos, $"Casa Civil {i} de {cityName}");
        }

        // Generar Gremio de Aventureros (Donde Mukouda vende la carne de monstruo)
        mapZones.Add(position + new Vector3(0, 0, -30), $"Gremio de Aventureros de {cityName}");

        // Generar la Posada / Cuarto de Renta de Mukouda
        if (cityName == "Ciudad de Karelina")
        {
            rentedRoomPosition = position + new Vector3(30, 0, 30);
            mapZones.Add(rentedRoomPosition, "Posada del Sol: Cuarto Rentado de Mukouda (Permite dormir a Fel y Sui)");
        }
    }

    public Vector3 GetRentedRoomPosition()
    {
        return rentedRoomPosition;
    }

    public string CheckLocation(Vector3 playerPos)
    {
        foreach (var zone in mapZones)
        {
            if (Vector3.Distance(playerPos, zone.Key) < 10f)
            {
                return zone.Value;
            }
        }
        return "Praderas del Otro Mundo (Monstruos Salvajes Cercanos)";
    }
}
