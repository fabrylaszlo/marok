using NUnit.Framework

namespace Tesztek
{
    public class Alaptesztek{
        [Test]
        public void Alapteszt()
        {
            var counter = new BasicCounter(count: 0);

            counter.Increment();
             
            Assert.AreEqual(expected:1,actual:counter.Count);
        }
    }
    
}