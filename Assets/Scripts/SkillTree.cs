using TMPro;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public TMP_Text skillDescription;
    public Skill[] skills;

    public int coins = 0;
    Skill selectedSkill;

    void Start()
    {
        
    }

    public void SelectSkill(int skill)
    {
        selectedSkill = skills[skill];

        skillDescription.SetText(selectedSkill.description);
    }

    // Update is called once per frame
    public void PurchaseSkill()
    {

    }
}