using MicrosoftResearch.Infer.Learners;

namespace InferTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataMapping = new CsvMapping();
            var recommender = MatchboxRecommender.Create(dataMapping);
            recommender.Settings.Training.TraitCount = 5;
            recommender.Settings.Training.IterationCount = 20;
            recommender.Train("C:\\Python\\data\\ml-latest-small\\ratings.csv");
            recommender.Save("C:\\Python\\data\\ml-latest-small\\TrainedModel.bin");
            var recommends = recommender.Recommend("1", 10);
            int rating = recommender.Predict("23", "6669");
            rating = recommender.Predict("1", "31");
            rating = recommender.Predict("2", "17");
        }
    }
}
