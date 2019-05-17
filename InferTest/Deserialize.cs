
using MicrosoftResearch.Infer.Learners;

namespace InferTest
{
    public class Deserializer : ILearner
    {
        ICapabilities ILearner.Capabilities => throw new System.NotImplementedException();

        ISettings ILearner.Settings => throw new System.NotImplementedException();
    }
}
