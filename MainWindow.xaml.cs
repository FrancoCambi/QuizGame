using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static readonly Dictionary<string, List<string>> questions = new()
        {
            { "Que significan las siglas CPU?",  new List<string> {
                                                "Central Processing Unit.", 
                                                "Change Proces Unit.", 
                                                "Central Partial Unit.", 
                                                "Central Processing Uniform."} 
            },
            { "Cuál es el planeta más cercano al Sol?",  new List<string> { 
                                                        "Tierra", 
                                                        "Venus", 
                                                        "Mercurio", 
                                                        "Plutón"} 
            },
            { "Cuál es el planeta más caliente del sistema solar?",  new List<string> {
                                                                    "Júpiter",
                                                                    "Venus",
                                                                    "Mercurio",
                                                                    "Saturno"}
            },
            { "Como se llama el agujero negro situado en el centro de la galaxia Vía Lactea?",  new List<string> {
                                                                                                "Hércules B",
                                                                                                "Sagitario B",
                                                                                                "Próxima Centauri",
                                                                                                "Sagitario A"}
            },
            { "A cuanto viaja la luz aproximadamente?",  new List<string> {
                                                        "250.000 km/s",
                                                        "300.000 km/h",
                                                        "485.987 km/s",
                                                        "300.000 km/s"}
            },
            { "Cuanto tarda la luz del sol en llegar a la Tierra aproximadamente?",  new List<string> {
                                                                                    "15 minutos",
                                                                                    "1 segundo",
                                                                                    "< 1 segundo",
                                                                                    "7 minutos"}
            },
            { "Europa es satélite natural de qué planeta?",  new List<string> {
                                                            "Saturno",
                                                            "Marte",
                                                            "Júpiter",
                                                            "Venus"}
            },
        };

        private readonly List<string> answers = new()
        {
            "Central Processing Unit.",
            "Mercurio",
            "Venus",
            "Sagitario A",
            "300.000 km/s",
            "7 minutos",
            "Júpiter"
        };

        private readonly int totalQuestions = questions.Count;

        private GameState gameState = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            SetQuiz();
        }

        /// <summary>
        /// Setea la primera vez los textos.
        /// </summary>
        private void SetQuiz()
        {
            Question.Text = questions.ElementAt(0).Key;
            List<string> options = questions.ElementAt(gameState.QuestionNum - 1).Value;

            AnswerA.Content = options[0];
            AnswerB.Content = options[1];
            AnswerC.Content = options[2];
            AnswerD.Content = options[3];

            QuestionNumber.Text = $"Pregunta {gameState.QuestionNum}/{totalQuestions}";

            Vidas.Text = $"Vidas: {gameState.Lives}/{gameState.TotalLives}";
        }

        /// <summary>
        /// Dado un index, devuelve el botón de respuestas correspondientes arrancando en 0
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Button GetAnswerFromIndex(int index)
        {
            Button resultado;

            switch (index)
            {
                case 0:
                    resultado =  AnswerA;
                    break;
                case 1:
                    resultado = AnswerB;
                    break;
                case 2:
                    resultado = AnswerC;
                    break;
                case 3:
                    resultado = AnswerD;
                    break;
                default:
                    resultado = new();
                    break;

            }

            return resultado;
        }

        private void ResetButtonsBackground()
        {
            AnswerA.ClearValue(Button.BackgroundProperty);
            AnswerB.ClearValue(Button.BackgroundProperty);
            AnswerC.ClearValue(Button.BackgroundProperty);
            AnswerD.ClearValue(Button.BackgroundProperty);
        }

        /// <summary>
        /// Hide un botón de respuestas by index arrancando en 0
        /// </summary>
        /// <param name="index"></param>
        private void HideButtonByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    AnswerA.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    AnswerB.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    AnswerC.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    AnswerD.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Vuelve a mostrar algún botón de respuestas by index arrancando en 0
        /// </summary>
        /// <param name="index"></param>
        private void UnHideButtonByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    AnswerA.Visibility = Visibility.Visible;
                    break;
                case 1:
                    AnswerB.Visibility = Visibility.Visible;
                    break;
                case 2:
                    AnswerC.Visibility = Visibility.Visible;
                    break;
                case 3:
                    AnswerD.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        

        /// <summary>
        /// Se llama automáticamente al presionar el botón de la respuesta A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerA_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.QuestionNum <= totalQuestions)
            {
                QuestionAnswered(AnswerA);
            }
        }

        /// <summary>
        /// Se llama automáticamente al presionar el botón de la respuesta B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerB_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.QuestionNum <= totalQuestions)
            {
                QuestionAnswered(AnswerB);
            }
        }

        /// <summary>
        /// Se llama automáticamente al presionar el botón de la respuesta C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerC_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.QuestionNum <= totalQuestions)
            {
                QuestionAnswered(AnswerC);
            }
        }

        /// <summary>
        /// Se llama automáticamente al presionar el botón de la respuesta D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerD_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.QuestionNum <= totalQuestions)
            {
                QuestionAnswered(AnswerD);
            }
        }

        /// <summary>
        /// Se llama automáticamente al presionar el botón del comodín
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoChanceCom_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string answer = answers[gameState.QuestionNum - 1];
            List<string> options = questions.ElementAt(gameState.QuestionNum - 1).Value;

            int randomIndex1;
            int randomIndex2;

            do
            {
                randomIndex1 = random.Next(4);
                randomIndex2 = random.Next(4);

            } while (options[randomIndex1] == answer || options[randomIndex2] == answer || randomIndex1 == randomIndex2);

            HideButtonByIndex(randomIndex1);
            HideButtonByIndex(randomIndex2);

            TwoChanceCom.IsEnabled = false;
            TwoChanceCom.Opacity = 0.5;
        }

        /// <summary>
        /// Se llama luego de contestar una pregunta y maneja lo que pasa luego
        /// </summary>
        /// <param name="answer"></param>
        private async void QuestionAnswered(Button answer)
        {
            string correctAnswer = answers[gameState.QuestionNum - 1];

            if ((string)answer.Content == correctAnswer)
            {

                answer.Background = Brushes.Green;
                gameState.CorrectAnswers++;
            }
            else
            {
                List<string> options = questions.ElementAt(gameState.QuestionNum - 1).Value;
                int correctAnswerIndex = options.IndexOf(correctAnswer);
                Button correctAnswerButton = GetAnswerFromIndex(correctAnswerIndex);
                correctAnswerButton.Background = Brushes.Green;

                answer.Background = Brushes.Red;

                gameState.Lives--;
            }


            gameState.QuestionNum++;

            if (gameState.QuestionNum > totalQuestions || gameState.Lives <= 0)
            {
                await Task.Delay(750);
                GameEnded();
            }
            else
            {
                await Task.Delay(750);
                ResetButtonsBackground();
                QuestionNumber.Text = $"Pregunta {gameState.QuestionNum}/{totalQuestions}";

                Vidas.Text = $"Vidas: {gameState.Lives}/3";

                Question.Text = questions.ElementAt(gameState.QuestionNum - 1).Key;

                List<string> options = questions.ElementAt(gameState.QuestionNum - 1).Value;

                AnswerA.Content = options[0];
                AnswerB.Content = options[1];
                AnswerC.Content = options[2];
                AnswerD.Content = options[3];
            }

            // Mostrar de nuevo los que desaparecieron por el uso del comodín
            UnHideButtonByIndex(0);
            UnHideButtonByIndex(1);
            UnHideButtonByIndex(2);
            UnHideButtonByIndex(3);


        }

        /// <summary>
        /// Se llama al terminar el quiz o a quedarse sin vidas y muestra la pantalla final
        /// </summary>
        private void GameEnded()
        {
            QuizGrid.Visibility = Visibility.Hidden;
            EndGrid.Visibility = Visibility.Visible;

            EndCorrectAnswers.Text = $"Respuestas correctas {gameState.CorrectAnswers} de {totalQuestions} " +
                $"({Math.Round((float)gameState.CorrectAnswers / (float)totalQuestions * 100)}%)";

            EndLivesRemaining.Text = $"Vidas restantes {gameState.Lives} de {gameState.TotalLives}";
        }
    }
}
