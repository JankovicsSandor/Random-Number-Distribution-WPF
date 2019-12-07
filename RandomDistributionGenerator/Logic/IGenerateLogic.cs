using System;

namespace RandomDistributionGenerator.Logic
{
    public interface IGenerateLogic
    {
        event EventHandler<int> NumberGenerated;

        void GenerateNumbers(int length, int min, int max);
    }
}