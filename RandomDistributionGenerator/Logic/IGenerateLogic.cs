using System;

namespace RandomDistributionGenerator.Logic
{
    public interface IGenerateLogic
    {
        event EventHandler<int> NumberGenerated;
        event EventHandler<int> ProgressbarUpdate;

        void GenerateNumbers(int length, int min, int max);
    }
}