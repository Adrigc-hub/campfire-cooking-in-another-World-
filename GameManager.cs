using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Progreso de la Historia")]
    public int currentChapter = 1;
    public bool hasContractsWithPets = false;

    private VRPlayerController player;
    private float rentTimer = 0f;

    void Start()
    {
        player = FindObjectOfType<VRPlayerController>();
        TriggerStoryDialog();
    }

    void Update()
    {
        // Simular cobro de renta por tiempo en la posada del mundo abierto (cada 5 minutos de juego real)
        rentTimer += Time.deltaTime;
        if (rentTimer >= 300f)
        {
            rentTimer = 0f;
            PayRentedRoom();
        }
    }

    public void AdvanceStory()
    {
        currentChapter++;
        TriggerStoryDialog();
    }

    void TriggerStoryDialog()
    {
        switch (currentChapter)
        {
            case 1:
                Debug.Log("Historia Cap 1: Has sido invocado por error. Escapas del reino usando tu habilidad de Supermercado Online.");
                break;
            case 2:
                hasContractsWithPets = true;
                Debug.Log("Historia Cap 2: ¡Fel se sintió atraído por el olor de tu comida! Has firmado un contrato con el Lobo Legendario.");
                break;
            case 3:
                Debug.Log("Historia Cap 3: Encuentras a Sui, el Slime bebé en el camino. Ahora viajas de ciudad en ciudad rentando cuartos.");
                break;
        }
    }

    void PayRentedRoom()
    {
        Debug.Log("Es fin de mes en el juego. El encargado de la Posada te pide el pago de la renta del cuarto.");
        // Te cuesta 3 monedas de plata mantener tu casa/habitación activa
        player.SpendMoney(0, 3);
    }
}
