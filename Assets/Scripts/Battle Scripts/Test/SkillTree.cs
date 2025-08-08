using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    private List<string> skills;

    public SkillTree()
    {
        skills = new List<string> { "Basic Study" };
    }

    public void ChooseSkill()
    {
        Debug.Log("Choose a skill to learn:");
        Debug.Log("1. Advanced Study\n2. Quick Revision\n3. Group Study");
        int choice = 0;

        // In Unity, input handling would be UI-based, here we simulate input
        // You should connect this to UI buttons or input fields
        // For demo, assume choice is set externally or via debug console

        // Example placeholder (replace with your input method)
        // choice = int.Parse(Console.ReadLine());

        // Just to show logic, assuming choice = 1
        choice = 1;

        switch (choice)
        {
            case 1:
                skills.Add("Advanced Study");
                Debug.Log("Learned Advanced Study!");
                break;
            case 2:
                skills.Add("Quick Revision");
                Debug.Log("Learned Quick Revision!");
                break;
            case 3:
                skills.Add("Group Study");
                Debug.Log("Learned Group Study!");
                break;
            default:
                Debug.Log("Invalid choice.");
                break;
        }
    }

    public void ShowSkills()
    {
        Debug.Log("Skills learned:");
        foreach (var skill in skills)
        {
            Debug.Log("- " + skill);
        }
    }
}
