using UnityEngine;
using System.Collections;

public class Beard : MonoBehaviour
{
	public Sprite[] sprites = new Sprite[10];
	public float hairs = 0;
	public float hairsPerSecond = 0;
	public bool won = false;
    public Font font;

	private bool storeOpen = false;
    private Rect storeButtonRect;
    private Rect storeRect;
    private int storeItemHeight;
    private Texture2D buttonTexture;

    //Buildings
    public int cursors;
    public int grandmas;
    public int farms;
    public int factories;
    public int mines;
    public int shipments;
    public int potions;
    public int portals;
    public int timemachines;
    public int antimattercondensers;
    public int gods;

	void Start()
	{
		SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
		spriteRenderer.sprite = sprites[0];

        LoadGame();

        StartCoroutine(AddHairsPerSecond());
        StartCoroutine(SaveGame());
	}

	void Update()
	{
		if (!won)
		{
			SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

            storeItemHeight = Screen.height / 11;

            

			if (hairs < 5)
			{
				spriteRenderer.sprite = sprites[0];
			}
			else if (hairs >= 5 && hairs < 100)
			{
				spriteRenderer.sprite = sprites[1];
			}
			else if (hairs >= 100 && hairs < 1000)
			{
				spriteRenderer.sprite = sprites[2];
			}
			else if (hairs >= 1000 && hairs < 10000)
			{
				spriteRenderer.sprite = sprites[3];
			}
			else if (hairs >= 10000 && hairs < 100000)
			{
				spriteRenderer.sprite = sprites[4];
			}
			else if (hairs >= 100000 && hairs < 1000000)
			{
				spriteRenderer.sprite = sprites[5];
			}
			else if (hairs >= 1000000 && hairs < 10000000)
			{
				spriteRenderer.sprite = sprites[6];
			}
			else if (hairs >= 10000000 && hairs < 100000000)
			{
				spriteRenderer.sprite = sprites[7];
			}
			else if (hairs >= 100000000 && hairs < 1000000000)
			{
				spriteRenderer.sprite = sprites[8];
			}
			else if (hairs >= 1000000000 && hairs < 10000000000)
			{
				spriteRenderer.sprite = sprites[9];
				won = true;
			}
		}
	}

	void OnGUI()
	{
        if (!won)
        {
            GUIStyle normalStyle = new GUIStyle();
            Rect labelRect = GUILayoutUtility.GetRect(new GUIContent("S\nT\nO\nR\nE"), normalStyle);
            float storeOffset = 0;

            if (storeOpen)
                storeOffset = Screen.width * 0.35f;
            else
                storeOffset = 0;

            storeButtonRect = new Rect(Screen.width - (labelRect.width + 10) - storeOffset, (Screen.height / 2) - ((labelRect.height + 10) / 2), labelRect.width + 10, labelRect.height + 10);
            storeRect = new Rect(Screen.width - storeOffset, 0, Screen.width * 0.35f, Screen.height);

            if (GUI.Button(new Rect(0, 0, Screen.width * 0.35f, Screen.height * 0.25f), "CLICK TO GROW A BEARD"))
            {
                hairs++;
            }

            GUIStyle style = new GUIStyle();
            style.fontSize = 24;

            GUI.Label(new Rect(25, Screen.height * 0.25f + 25, 1000, 1000), "Hairs: " + hairs.ToString("#,##0.#") + "\nHpS: " + hairsPerSecond.ToString("#,##0.#"), style);

            if (GUI.Button(storeButtonRect, "S\nT\nO\nR\nE"))
            {
                if (!storeOpen)
                {
                    storeOpen = true;
                }
                else
                {
                    storeOpen = false;
                }
            }

            GUI.Box(storeRect, "");

            StoreButton("Beard Cursor", 0, cursors);
            StoreButton("Beard Grandma", 1, grandmas);
            StoreButton("Beard Farm", 2, farms);
            StoreButton("Beard Factory", 3, factories);
            StoreButton("Beard Mine", 4, mines);
            StoreButton("Beard Shipment", 5, shipments);
            StoreButton("Beard Potion", 6, potions);
            StoreButton("Beard Portal", 7, portals);
            StoreButton("Beard Time Machine", 8, timemachines);
            StoreButton("Beard Condenser", 9, antimattercondensers);
            StoreButton("Beard God", 10, gods);
        }
        else
        {
            GUIStyle headerStyle = new GUIStyle();
            headerStyle.font = font;
            headerStyle.font.material.color = Color.white;
            headerStyle.fontSize = 72;
            GUI.skin.label.fontSize = 72;

            Rect headerRect = GUILayoutUtility.GetRect(new GUIContent("You Win!"), headerStyle);

            GUI.Label(new Rect((Screen.width / 2) - (headerRect.width / 2), 25, headerRect.width, headerRect.height), "You Win!");

            if (GUI.Button(new Rect(25, Screen.height - 75, Screen.width - 50, 50), "Play Again"))
            {
                hairsPerSecond = 0;
                hairs = 0;
                cursors = 0;
                grandmas = 0;
                farms = 0;
                factories = 0;
                mines = 0;
                shipments = 0;
                potions = 0;
                portals = 0;
                timemachines = 0;
                antimattercondensers = 0;
                gods = 0;
                won = false;
            }
        }
	}

    void StoreButton(string name, int index, int variable)
    {
        float price = 0;

        if (name == "Beard Cursor")
        {
            price = 15 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Grandma")
        {
            price = 100 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Farm")
        {
            price = 500 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Factory")
        {
            price = 3000 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Mine")
        {
            price = 10000 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Shipment")
        {
            price = 40000 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Potion")
        {
            price = 200000 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Portal")
        {
            price = 1666666 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Time Machine")
        {
            price = 123456789 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard Condenser")
        {
            price = 500000000 * Mathf.Pow(1.15f, variable);
        }
        else if (name == "Beard God")
        {
            price = 1000000000 * Mathf.Pow(1.15f, variable);
        }

        int i = (int)price;

        if (i > 0)
        {
            if (GUI.Button(new Rect(storeRect.x, storeRect.y + (storeItemHeight * index), storeRect.width, storeItemHeight), variable + " - " + name + " (" + (int)price + " Hairs)"))
            {
                if (hairs >= price)
                {
                    if (name == "Beard Cursor")
                    {
                        cursors++;
                        hairsPerSecond += 0.1f;
                    }
                    else if (name == "Beard Grandma")
                    {
                        grandmas++;
                        hairsPerSecond += 0.5f;
                    }
                    else if (name == "Beard Farm")
                    {
                        farms++;
                        hairsPerSecond += 4;
                    }
                    else if (name == "Beard Factory")
                    {
                        factories++;
                        hairsPerSecond += 10;
                    }
                    else if (name == "Beard Mine")
                    {
                        mines++;
                        hairsPerSecond += 40;
                    }
                    else if (name == "Beard Shipment")
                    {
                        shipments++;
                        hairsPerSecond += 100;
                    }
                    else if (name == "Beard Potion")
                    {
                        potions++;
                        hairsPerSecond += 400;
                    }
                    else if (name == "Beard Portal")
                    {
                        portals++;
                        hairsPerSecond += 6666;
                    }
                    else if (name == "Beard Time Machine")
                    {
                        timemachines++;
                        hairsPerSecond += 98765;
                    }
                    else if (name == "Beard Condenser")
                    {
                        antimattercondensers++;
                        hairsPerSecond += 999999;
                    }
                    else if (name == "Beard God")
                    {
                        gods++;
                        hairsPerSecond += 10000000;
                    }

                    hairs -= price;
                }
            }
        }
    }

    IEnumerator AddHairsPerSecond()
    {
        while (true)
        {
            hairs += hairsPerSecond;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SaveGame()
    {
        while (true)
        {
            PlayerPrefs.SetFloat("hairs", hairs);
            PlayerPrefs.SetFloat("hairsPerSecond", hairsPerSecond);
            PlayerPrefs.SetInt("cursors", cursors);
            PlayerPrefs.SetInt("grandmas", grandmas);
            PlayerPrefs.SetInt("farms", farms);
            PlayerPrefs.SetInt("factories", factories);
            PlayerPrefs.SetInt("mines", mines);
            PlayerPrefs.SetInt("shipments", shipments);
            PlayerPrefs.SetInt("potions", potions);
            PlayerPrefs.SetInt("portals", portals);
            PlayerPrefs.SetInt("timemachines", timemachines);
            PlayerPrefs.SetInt("antimattercondensers", antimattercondensers);
            PlayerPrefs.SetInt("gods", gods);
            yield return new WaitForSeconds(30);
        }
    }

    void LoadGame()
    {
        hairs = PlayerPrefs.GetFloat("hairs", 0);
        hairsPerSecond = PlayerPrefs.GetFloat("hairsPerSecond", 0);
        cursors = PlayerPrefs.GetInt("cursors", 0);
        grandmas = PlayerPrefs.GetInt("grandmas", 0);
        farms = PlayerPrefs.GetInt("farms", 0);
        factories = PlayerPrefs.GetInt("factories", 0);
        mines = PlayerPrefs.GetInt("mines", 0);
        shipments = PlayerPrefs.GetInt("shipments", 0);
        potions = PlayerPrefs.GetInt("potions", 0);
        portals = PlayerPrefs.GetInt("portals", 0);
        timemachines = PlayerPrefs.GetInt("timemachines", 0);
        antimattercondensers = PlayerPrefs.GetInt("antimattercondensers", 0);
        gods = PlayerPrefs.GetInt("gods", 0);
    }
}