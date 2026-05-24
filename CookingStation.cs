using UnityEngine;

public class CookingStation : MonoBehaviour
{
    [Header("Estado de la Cocina")]
    public string ingredient1 = "";
    public string ingredient2 = "";

    public void AddIngredientFromVRHand(string ingredientName)
    {
        if (ingredient1 == "") ingredient1 = ingredientName;
        else if (ingredient2 == "") ingredient2 = ingredientName;

        Debug.Log($"Añadido a la sartén VR: {ingredientName}");

        if (ingredient1 != "" && ingredient2 != "")
        {
            CookDish();
        }
    }

    void CookDish()
    {
        Debug.Log($"Cocinando: {ingredient1} mezclado con {ingredient2}...");
        
        string finalDish = "Platillo Misterioso";
        float buffMultiplier = 1.0f;

        // Receta de la Historia: Carne de Monstruo + Salsa de la Tierra
        if ((ingredient1.Contains("Carne") && ingredient2.Contains("Salsa")) || 
            (ingredient1.Contains("Salsa") && ingredient2.Contains("Carne")))
        {
            finalDish = "Estofado de Jabalí de Júpiter con Salsa de la Tierra";
            buffMultiplier = 2.5f; // Multiplica el poder de ataque por el lore del anime
        }

        Debug.Log($"¡Platillo Terminado: {finalDish}! Listo para alimentar a tus mascotas.");
        
        // Aplicar buff a las mascotas que estén cerca de la fogata
        FamiliarPet[] pets = FindObjectsOfType<FamiliarPet>();
        foreach (FamiliarPet pet in pets)
        {
            pet.FeedFamiliar(finalDish, buffMultiplier);
        }

        // Limpiar sartén
        ingredient1 = "";
        ingredient2 = "";
    }
}
