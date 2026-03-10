using TMPro;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public TMP_Text skillDescription;
    public TMP_Text coinsDisplay;
    public Skill[] skills;
    public Sound confirmSound;
    public Sound denySound;

    public int coins = 0;
    Skill selectedSkill;
    public bool openedBefore = false;

    void Update()
    {
        coinsDisplay.SetText($"Coins: ${coins}");
    }

    public void SelectSkill(int skill)
    {
        selectedSkill = skills[skill];

        skillDescription.SetText(selectedSkill.description);
    }

    // Update is called once per frame
    public void PurchaseSkill()
    {
        if (coins < selectedSkill.coins)
        {
            AudioManager.Instance.PlaySound(denySound);
        }
        else if (selectedSkill.name == "Ultra Jump")
        {
            AudioManager.Instance.PlaySound(confirmSound);

            GameObject.Find("Player").GetComponent<PlayerMovement>().currentJumpHeight += 0.2f;
            coins -= selectedSkill.coins;
        }
        
    }
}