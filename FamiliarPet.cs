using UnityEngine;

public class FamiliarPet : MonoBehaviour
{
    public enum FamiliarType { Fel, Sui }
    [Header("Configuración de Mascota")]
    public FamiliarType tipoMascota;
    public int nivel = 1;
    public float vida = 100f;
    public float ataqueBase = 50f;
    public float hambre = 100f; // 100 = Lleno, 0 = Muere de hambre

    private float dañoActual;

    void Start()
    {
        dañoActual = ataqueBase;
        if (tipoMascota == FamiliarType.Fel) { vida = 5000f; ataqueBase = 1200f; dañoActual = ataqueBase; }
        if (tipoMascota == FamiliarType.Sui) { vida = 300f; ataqueBase = 150f; dañoActual = ataqueBase; }
    }

    void Update()
    {
        // El hambre baja con el tiempo en el mundo abierto
        hambre -= Time.deltaTime * 0.1f;
        if (hambre < 30f)
        {
            Debug.LogWarning($"¡{tipoMascota} tiene mucha hambre! Su ataque bajó a la mitad. ¡Mukouda, cocina algo!");
            dañoActual = ataqueBase * 0.5f;
        }
    }

    public void FeedFamiliar(string dishName, float multiplier)
    {
        hambre = 100f;
        dañoActual = ataqueBase * multiplier;
        Debug.Log($"¡{tipoMascota} devoró {dishName}! Hambre restaurada. Daño actual aumentado a: {dañoActual}");
    }

    // Sistema de Pelea Automática en Mundo Abierto
    public void AttackEnemy(GameObject enemy)
    {
        if (hambre <= 0) return;

        Debug.Log($"{tipoMascota} está atacando al enemigo usando sus habilidades del anime...");
        
        if (tipoMascota == FamiliarType.Fel)
        {
            Debug.Log("¡Fel usó: Magia de Viento - Cortador de Vacío!");
        }
        else if (tipoMascota == FamiliarType.Sui)
        {
            Debug.Log("¡Sui usó: Disparo de Ácido Corrosivo!");
        }

        // Simular daño al enemigo
        Destroy(enemy); 
        Debug.Log("¡Enemigo derrotado por tus mascotas! Recoges Carne de Monstruo del suelo.");
        
        // Dar recompensa al jugador
        FindObjectOfType<VRPlayerController>().goldCoins += 10;
        
        GainXP();
    }

    void GainXP()
    {
        nivel++;
        vida += 50;
        ataqueBase += 20;
        Debug.Log($"¡{tipoMascota} subió de nivel! Nivel Actual: {nivel}");
    }
}
