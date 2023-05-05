using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaneANN;
using static LaneLibrary.ConsoleUtils;

namespace LaneFinal
{
    public class Game
    {
        public NeuralNetWork network;
        public bool playerAlive;
        public int score;

        public Game()
        {
            network = new NeuralNetWork(1, 6);

            var trainingInputs = new double[,]
            {
                { 1, 1, 1, 1, 1, 1 },
                { 0, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 1, 1, 1 },
                { 1, 1, 0, 1, 1, 1 },

                { 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0 },

                { 0, 0, 0, 1, 1, 1 },
                { 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 0, 1 },
                { 1, 1, 1, 0, 1, 0 }
            };
            var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 } });

            network.Train(trainingInputs, trainingOutputs, 1000000);
        }

        public void Run()
        {
            playerAlive = true;
            score = 0;

            Print("You enter a deep and dark dungeon.");

            Print();

            WaitForKeyPress(true);
            ClearScrollable();

            while (playerAlive)
            {
                Turn();
            }

            Print("You have perished in the dungeon.");

            Print();

            Print("Final score: " + score.ToString());

            Print();

            Print("Play again? ");
            if (GetInputBool())
            {
                ClearScrollable();
                Run();
            }

        }

        public void Turn()
        {
            Print("New turn! Your Score: " + score.ToString());

            Print();

            Print("You come across a monster in the dungeon.");

            Print();

            Print("MONSTER'S TURN TO CHOOSE ATTACKS.");

            double[,] monsterInput = new double[1, 6];

            for (int i = 0; i < 6; i++)
            {
                double monsterChoice = network._randomObj.Next(2);
                Print("Monster chose: " + monsterChoice.ToString());
                monsterInput[0, i] = monsterChoice;

            }

            double monsterOutput = network.Think(monsterInput)[0, 0];

            //Print("Monster Output: " + monsterOutput.ToString("F"));

            Print();

            Print("PLAYER'S TURN TO CHOOSE ATTACKS.");

            double[,] playerInput = new double[1, 6];

            for (int i = 0; i < 6; i++)
            {
                playerInput[0, i] = GetInputIntKey(0, 1);

            }

            double playerOutput = network.Think(playerInput)[0, 0];

            //Print("Player Output: " + playerOutput.ToString("F"));

            Print();

            Print("Simulating battle...");

            Print();

            if (monsterOutput > playerOutput)
            {
                playerAlive = false;
                Print("The monster defeated you.");
                
            }
            else
            {
                score += 1;
                Print("Monster defeated! +1 score");
                
            }

            WaitForKeyPress(true);
            ClearScrollable();
        }
    }
}
