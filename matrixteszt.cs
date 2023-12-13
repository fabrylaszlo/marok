using NUnit.Framework

namespace Tesztek
{
    public class Matrixteszt{
        [Test]
        public void Shouldreturnnegative()
        {
            Matrix m = new Matrix(new float[.])
           {
            {-1,0},
            {0,2}
           });
           Matrix m2 = -m;
           Assert.AreNotSame(m,m2);
           Assert.AreEqual(m2[0,0],1);
           Assert.AreEqual(m2[0,1],0);
           Assert.AreEqual(m2[1,0],0);
           Assert.AreEqual(m2[1,1],-2);
        }
    }
    
}