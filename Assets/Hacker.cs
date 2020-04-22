using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "Octopussy", "Pickle Rip", "Hoe Bot", "Turtle Reaper", "Eric Half Tree" };
    string[] level2Passwords = { "Child Whipserer", "Master of Boots", "Eater of Pickles", "Machias Savings Bitch" };
    string[] level3Passwords = { "Wielder of the Meme Beam", "Holder the Freehold Key", "Lord of the Stealthy Bois", "Moistes Dad in the World", "Big enough for a child", "Unlocker of Justin's Box" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Guess the names of the one the call");
        Terminal.WriteLine("Eric the FreeBird!");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 to warm up!");
        Terminal.WriteLine("Press 2 ready for some pickles!");
        Terminal.WriteLine("Press 3 i know this guy!");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "eric") // easter egg
        {
            Terminal.WriteLine("Please select a level Daddy!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("mhm, ok your friends with Eric");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case 2:
                Terminal.WriteLine("mhm, best buds with this Guy?");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                Terminal.WriteLine("mhm, Like sicking Eric's Dick");
                Terminal.WriteLine("for a living, GG!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
