using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public GameObject[] Lasers;

    public MeshRenderer Renderer;

    public Material OffMaterial;
    public Material OnMaterial;

    Material cachedOffMaterial;
    Material cachedOnMaterial;

    bool isOn;
    bool playerNear;

    private void Start()
    {
        cachedOffMaterial = Material.Instantiate(OffMaterial);
        cachedOnMaterial = Material.Instantiate(OnMaterial);
        playerNear = false;

        ToggleOn();
    }

    private void Update()
    {
        if (!playerNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOn) ToggleOff();
            else ToggleOn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerNear = false;
    }

    public void ToggleOn()
    {
        isOn = true;

        Renderer.sharedMaterial = cachedOnMaterial;
        for (int i = 0; i < Lasers.Length; i++)
        {
            Lasers[i].SetActive(true);
        }
    }

    public void ToggleOff()
    {
        isOn = false;

        Renderer.sharedMaterial = cachedOffMaterial;
        for (int i = 0; i < Lasers.Length; i++)
        {
            Lasers[i].SetActive(false);
        }
    }
}
