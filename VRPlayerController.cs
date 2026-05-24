using UnityEngine;

public class VRPlayerController : MonoBehaviour
{
    [Header("Monedas en el Otro Mundo")]
    public int goldCoins = 150;
    public int silverCoins = 50;

    [Header("VR Input Simulado")]
    public Transform leftHand;
    public Transform rightHand;

    private string currentZone = "";

    void Update()
    {
        // Monitorear en qué parte del mundo abierto está el jugador
        string zone = WorldManager.Instance.CheckLocation(transform.position);
        if (zone != currentZone)
        {
            currentZone = zone;
            Debug.Log($"[VR HUD] Has entrado a: {currentZone}");
        }

        // Simulación VR: Presionar botón X en control izquierdo abre Supermercado Online
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.S))
        {
            OpenSupermarketMenu();
        }
    }

    public void OpenSupermarketMenu()
    {
        Debug.Log("--- MENU VR: SUPERMERCADO NETO ABIERTO (Habilidad Única) ---");
        Debug.Log("1. Salsa Teriyaki Japonesa (2 Monedas de Plata)");
        Debug.Log("2. Carne de Res de Alta Calidad (5 Monedas de Plata)");
        Debug.Log("3. Estufa de Gas Portátil (1 Moneda de Oro)");
    }

    public bool SpendMoney(int gold, int silver)
    {
        if (goldCoins >= gold && silverCoins >= silver)
        {
            goldCoins -= gold;
            silverCoins -= silver;
            Debug.Log($"Compra exitosa. Oro restante: {goldCoins}, Plata: {silverCoins}");
            return true;
        }
        Debug.Log("¡No tienes suficiente dinero! Ve al Gremio a vender materiales de monstruo.");
        return false;
    }

    public void TeleportToRentedRoom()
    {
        Vector3 room = WorldManager.Instance.GetRentedRoomPosition();
        transform.position = room;
        Debug.Log("Te has teletransportado a tu habitación rentada segura para descansar.");
    }
}
