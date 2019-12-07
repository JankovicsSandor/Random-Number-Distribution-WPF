using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace RandomDistributionGenerator.Logic
{

    class GenerateLogic : IGenerateLogic
    {
        static Random r = new Random();

        public event EventHandler<int> NumberGenerated;

        public event EventHandler<int> ProgressbarUpdate;

        public void GenerateNumbers(int length, int min, int max)
        {
            int random = 0;
            for (int i = 0; i < length; i++)
            {
                random = r.Next(min, max);
                NumberGenerated?.Invoke(this, random);
                Debug.WriteLine((double)i / length);
                ProgressbarUpdate?.Invoke(this, (int)(((double)i/length)*100));

            }
        }
    }
}
