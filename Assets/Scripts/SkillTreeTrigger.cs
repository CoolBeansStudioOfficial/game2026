using UnityEngine;

public class SkillTreeTrigger : Trigger
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (alreadyTriggered) return;

        if (collider.CompareTag("Player"))
        {
            UIManager.Instance.canOpenSkillTree = true;
        }
    }
}
