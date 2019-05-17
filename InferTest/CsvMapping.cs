using MicrosoftResearch.Infer.Learners;
using MicrosoftResearch.Infer.Learners.Mappings;
using MicrosoftResearch.Infer.Maths;
using System;
using System.Collections.Generic;
using System.IO;

namespace InferTest
{
    [Serializable]
    class CsvMapping : IStarRatingRecommenderMapping
    <string, Tuple<string, string, int>, string, string, int, NoFeatureSource, Vector>
    {
        public IEnumerable<Tuple<string, string, int>> GetInstances(string instanceSource)
        {
            foreach (string line in File.ReadLines(instanceSource))
            {
                string[] split = line.Split(new[] { ',' });

                double i;
                double.TryParse(split[2].Split('.')[0], out i);
                if (i == 0)
                    continue;

                yield return Tuple.Create(split[0], split[1], Convert.ToInt32(split[2].Split('.')[0]));
            }
        }

        public string GetUser(string instanceSource, Tuple<string, string, int> instance)
        {
            return instance.Item1;
        }

        public string GetItem(string instanceSource, Tuple<string, string, int> instance)
        {
            return instance.Item2;
        }

        public int GetRating(string instanceSource, Tuple<string, string, int> instance)
        {
            return instance.Item3;
        }

        public IStarRatingInfo<int> GetRatingInfo(string instanceSource)
        {
            return new StarRatingInfo(0, 5);
        }

        public Vector GetUserFeatures(NoFeatureSource featureSource, string user)
        {
            throw new NotImplementedException();
        }

        public Vector GetItemFeatures(NoFeatureSource featureSource, string item)
        {
            throw new NotImplementedException();
        }
    }
}
