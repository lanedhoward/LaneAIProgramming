namespace LaneANN
{
    /// <summary>
    /// Code adapted from https://medium.com/p/7e917e9fc2cc
    /// </summary>

    class Program
    {

        static void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        /*
         *  Neural network will decide if a game is a rogue-like or not
         *  
         *  Categories:
         *  Permadeath
         *  Focus on Survival
         *  Random Generation
         *  Dungeon Crawler
         *  Resource Management
         *  
         * 
         *  Games:
         *  Rogue
         *  Enter the Gungeon
         *  FTL
         *  risk of rain
         *  Minecraft
         *  Resident Evil 4
         *  Legend of Zelda
         *  Mario
         *  Super Hexagon
         *  Don't Starve
         *  The Stanley Parable
         *  
         *  Test games:
         *  Downwell
         *  The Sims
         *  
         *  it doesn't work particularly well yet, i think i may need a more complex neural net
         *  this one doesn't have multiple layers, or even biases yet
         */

        static void Main(string[] args)
        {
            var curNeuralNetwork = new NeuralNetWork(1, 5);

            Console.WriteLine("Synaptic weights before training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);

            var trainingInputs = new double[,] 
            { 
                { 1, 1, 1, 1, 1 }, // rogue
                { 1, 1, 1, 1, 1 }, // rogue
                { 1, 1, 1, 1, 1 }, // rogue
                { 1, 1, 1, 1, 1 }, // rogue
                { 1, 1, 1, 1, 1 }, // gungeon
                { 1, 1, 1, 0, 1 }, // ftl
                { 1, 1, 0, 1, 1 }, // risk of rain
                { 0, 0, 1, 0, 0 }, // minecraft
                { 0, 1, 0, 0, 1 }, // re4
                { 0, 0, 0, 1, 0 }, // loz
                { 0, 0, 0, 0, 0 }, // mario
                { 1, 1, 1, 0, 0 }, // super hexagon
                { 1, 1, 1, 0, 1 }, // don't starve
                { 1, 0, 0, 0, 0 }, // TSP
                { 0, 1, 0, 1, 1 } // fallout
            };
            var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 } });

            curNeuralNetwork.Train(trainingInputs, trainingOutputs, 1000000);

            Console.WriteLine("\nSynaptic weights after training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);


            // testing neural networks against a new problem 
            var output = curNeuralNetwork.Think(new double[,] { { 1, 1, 1, 1, 0 } });
            Console.WriteLine("\nConsidering new game Downwell { 1, 1, 1, 1, 0 } => :");
            PrintMatrix(output);

            output = curNeuralNetwork.Think(new double[,] { { 1, 0, 1, 0, 1 } });
            Console.WriteLine("\nConsidering new game The Sims { 1, 0, 1, 0, 1 } => :");
            PrintMatrix(output);

            output = curNeuralNetwork.Think(new double[,] { { 1, 1, 1, 1, 1 } });
            Console.WriteLine("\nConsidering new game Binding of Isaac { 1, 1, 1, 1, 1 } => :");
            PrintMatrix(output);

            output = curNeuralNetwork.Think(new double[,] { { 0, 0, 0, 0, 0 } });
            Console.WriteLine("\nConsidering new game Mario Kart { 0, 0, 0, 0, 0 } => :");
            PrintMatrix(output);

            Console.Read();

        }
    }
}