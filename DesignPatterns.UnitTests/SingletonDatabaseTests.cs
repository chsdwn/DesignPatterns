using NUnit.Framework;

namespace DesignPatterns.UnitTests
{
    [TestFixture]
    public class SingletonDatabaseTests
    {
        [Test]
        public void IsSingleton()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;

            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetTotalPopulation_AFewCityNames_ReturnSumOfPopulationOfGivenCities()
        {
            var finder = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };

            var result = finder.GetTotalPopulation(names);

            Assert.That(result, Is.EqualTo(17500000 + 17400000));
        }
    }
}