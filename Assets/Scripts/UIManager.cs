using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        //singleton initialization
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public DialogueReader dialogueReader;
    public SkillTree skillTree;
    public GameObject skillTreeView;
    public string skillTreeFirstOpenDialogue;

    public bool canOpenSkillTree = false;
    public bool playerLocked = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!canOpenSkillTree) return;
                
            skillTreeView.SetActive(!skillTreeView.activeSelf);

            playerLocked = skillTreeView.activeSelf;

            if (!skillTree.openedBefore)
            {
                dialogueReader.ReadDialogue(skillTreeFirstOpenDialogue);
                skillTree.openedBefore = true;
                 
            }
        }
    }
}
