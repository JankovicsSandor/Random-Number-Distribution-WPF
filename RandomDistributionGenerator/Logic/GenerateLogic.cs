using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomDistributionGenerator.Logic
{

    class GenerateLogic : IGenerateLogic
    {
        static Random r = new Random();

        public event EventHandler<int> NumberGenerated;

        public void GenerateNumbers(int length, int min, int max)
        {
            int random = 0;
            for (int i = 0; i < length; i++)
            {
                random = r.Next(min, max);
                NumberGenerated?.Invoke(this,random);
                Task.Delay(1000).Wait();
            }
        }
    }
}
