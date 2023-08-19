using HarmonogramNs;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework.Internal;

namespace HarmonogramTests
{
    [TestFixture]
    public class Tests
    {
        Dictionary<int, int> tempHarmonogram;
        Harmonogram sut;

        [SetUp]
        public void Setup()
        {
            tempHarmonogram = new Dictionary<int, int>();
            tempHarmonogram.Add(1, 0);
            tempHarmonogram.Add(2, 6);
            tempHarmonogram.Add(3, 5);
            tempHarmonogram.Add(4, 10);
            tempHarmonogram.Add(5, 13);
            tempHarmonogram.Add(6, 8);
            tempHarmonogram.Add(7, 3);
            tempHarmonogram.Add(8, 0);
            tempHarmonogram.Add(9, 12);
            tempHarmonogram.Add(10, 8);
            tempHarmonogram.Add(11, 1);
            tempHarmonogram.Add(12, 3);
            tempHarmonogram.Add(13, 12);
            tempHarmonogram.Add(14, 5);
            tempHarmonogram.Add(15, 0);
            tempHarmonogram.Add(16, 2);
            tempHarmonogram.Add(17, 1);
            tempHarmonogram.Add(18, 9);
            tempHarmonogram.Add(19, 13);
            tempHarmonogram.Add(20, 4);
            tempHarmonogram.Add(21, 12);
            tempHarmonogram.Add(22, 0);
            tempHarmonogram.Add(23, 9);
            tempHarmonogram.Add(24, 6);
            tempHarmonogram.Add(25, 5);
            tempHarmonogram.Add(26, 6);
            tempHarmonogram.Add(27, 11);
            tempHarmonogram.Add(28, 2);
            tempHarmonogram.Add(29, 0);
            tempHarmonogram.Add(30, 8);
            tempHarmonogram.Add(31, 10);


            sut = new Harmonogram(tempHarmonogram, 1);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void CzyPrzekraczaTest()
        {
            Assert.AreEqual(true, sut.CzyPrzekracza());
        }

        [Test]
        public void CzyPracaWNiedzieleTest()
        {
            Assert.AreEqual(false, sut.CzyPracaNiedziela());
        }

        [Test]
        public void NadgodzinyTest()
        {
            Assert.AreEqual(31, sut.IleNadgodzin());
        }

        [Test]
        public void CzyPrzekracza11test()
        {
            Assert.AreEqual(true, sut.CzyPrzekraczaJedenascie());
        }

        [Test]
        public void CzyPracaWNiedzieleTest2()
        {
            tempHarmonogram[1] = 3;
            sut = new Harmonogram(tempHarmonogram, 1);

            Assert.AreEqual(true, sut.CzyPracaNiedziela());
        }

        [Test]
        public void CzyPracaWNiedzieleTest3()
        {
            sut = new Harmonogram(tempHarmonogram, 3);

            Assert.AreEqual(true, sut.CzyPracaNiedziela());
        }

        [Test]
        public void NadgodzinyTest2()
        {
            Assert.AreEqual(31, sut.IleNadgodzin());
        }

        [Test]
        public void NadgodzinyTest3()
        {
            sut = new Harmonogram(tempHarmonogram, 5);
            Assert.AreEqual(56, sut.IleNadgodzin());
        }

        [Test]
        public void CzyPrzekraczaTest2()
        {
            for (int i = 0; i <= 31; i++)
            {
                tempHarmonogram[i] = 0;
            }

            sut = new Harmonogram(tempHarmonogram, 1);

            Assert.AreEqual(false, sut.CzyPrzekracza());
        }

        [Test]
        public void CzyPrzekraczaTest3()
        {
            for (int i = 0; i <= 31; i++)
            {
                tempHarmonogram[i] = 4;
            }

            sut = new Harmonogram(tempHarmonogram, 1);

            Assert.AreEqual(false, sut.CzyPrzekracza());
        }


        [Test]
        public void CzyPrzekracza11test2()
        {
            for (int i = 0; i <= 31; i++)
            {
                tempHarmonogram[i] = 15;
            }

            sut = new Harmonogram(tempHarmonogram, 1);

            Assert.AreEqual(true, sut.CzyPrzekraczaJedenascie());
        }


        [Test]
        public void CzyPrzekracza11test3()
        {
            for (int i = 0; i <= 31; i++)
            {
                tempHarmonogram[i] = 4;
            }

            sut = new Harmonogram(tempHarmonogram, 1);

            Assert.AreEqual(false, sut.CzyPrzekraczaJedenascie());
        }

    }
}