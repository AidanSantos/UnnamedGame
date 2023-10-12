using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodes : MonoBehaviour
{
    /*private static readonly KeyCode[] konamiCode =
    {
        KeyCode.UpArrow, KeyCode.UpArrow,
        KeyCode.DownArrow, KeyCode.DownArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.B, KeyCode.A
        
    };
    */

    private static readonly KeyCode[] mohgCode =
    {
        KeyCode.M, KeyCode.O,
        KeyCode.H, KeyCode.G
        
    };

    private int currentIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            /*
            if (Input.GetKeyDown(konamiCode[currentIndex]))
            {
                currentIndex++;

                if (currentIndex == konamiCode.Length)
                {
                    // Konami Code entered correctly, transition to the desired scene
                    //TransitionToMohg();
                }
            }
            else
            {
                // Reset if the wrong key is pressed
                currentIndex = 0;
            }
            */
            if (Input.GetKeyDown(mohgCode[currentIndex]))
            {
                currentIndex++;

                if (currentIndex == mohgCode.Length)
                {
                    // Mohg Code entered correctly, transition to the desired scene
                    TransitionToMohg();
                }
            }
            else
            {
                // Reset if the wrong key is pressed
                currentIndex = 0;
            }
        }
    }

    void TransitionToMohg()
    {
        SceneManager.LoadScene("Mohg");
    }
}
