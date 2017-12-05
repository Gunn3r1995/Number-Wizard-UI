using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NumberWizard : MonoBehaviour
    {
        private int _guess;

        public int min = 1;
        public int max = 1000;
        public int _maxGuessesAllowed = 10;
        public Text GuessText;

        // Use this for initialization
        void Start()
        {
            StartGame();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GuessHigher();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GuessLower();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Lose");
            }
        }
        
        private void StartGame()
        {
            _guess = Random.Range(min, max);
            GuessText.text = _guess.ToString();
            max++;
        }
        
        public void GuessLower()
        {
            max = _guess;
            NextGuess();
        }

        public void GuessHigher()
        {
            min = _guess;
            NextGuess();
        }

        private void NextGuess()
        {
            _guess = Random.Range(min, max);
            GuessText.text = _guess.ToString();
            _maxGuessesAllowed--;
            if (_maxGuessesAllowed <= 0)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}