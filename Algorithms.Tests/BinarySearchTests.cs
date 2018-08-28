using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests {
    using Algorithms;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTests {
        [TestCase(new int[] { }, 1, -1, TestName = "Empty array")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 99, -1, TestName = "Not present")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 0, TestName = "First Element")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, 2, TestName = "Middle Element")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 4, TestName = "Last Element")]
        public void BinarySearchRecursive(int[] a, int find, int expected) {
            Assert.AreEqual(expected, a.BinarySearchRecursive(find));
        }
        [TestCase(new int[] { }, 1, -1, TestName = "Empty array")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 99, -1, TestName = "Not present")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 0, TestName = "First Element")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, 2, TestName = "Middle Element")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 4, TestName = "Last Element")]
        public void BinarySearchImperative(int[] a, int find, int expected) {
            Assert.AreEqual(expected, a.BinarySearchImperative(find));
        }

        [TestCase(new float[] { }, 1f, -1, TestName = "Empty array")]
        [TestCase(new[] { 1f, 2f, 3f, 4f, 5f }, 99f, -6, TestName = "Not present")]
        [TestCase(new[] { 1f, 2f, 3f, 4f, 5f }, 1f, 0, TestName = "First Element")]
        [TestCase(new[] { 1f, 2f, 3f, 4f, 5f }, 3f, 2, TestName = "Middle Element")]
        [TestCase(new[] { 1f, 2f, 3f, 4f, 5f }, 5f, 4, TestName = "Last Element")]
        [TestCase(new[] { 1f, 2f, 3f, 4f, 5f }, 3.5f, -4, TestName = "Not Present, should be inserted")]
        public void BinarySearch(float[] a, float find, int expected) {
            var ret = a.BinarySearch(find);
            Assert.AreEqual(expected, ret);
            if (ret < 0) {
                var i = ~ret;
                if (i == 0) {
                    Assert.True(a.Length == 0 || a[0] > find);
                } else if (i >= a.Length) {
                    Assert.True(a[a.Length-1] < find);
                } else {
                    Assert.True(a[i-1] < find && a[i] > find);
                }
            }
        }

        [Test]
        public void BinarySearchRandom() {
            var arraySize = 100;
            var rand = new Random();
            for (int i = 0; i < 100; i++) {
                var l = new List<double>();
                for (int j = 0; j < arraySize; j++) {
                    l.Add(rand.NextDouble()*100);
                }
                var find = rand.NextDouble() * 100;
                var a = l.OrderBy(d => d).ToArray();

                var ret = a.BinarySearch(find);
                var expected = Array.BinarySearch(a, find);
                Assert.AreEqual(expected, ret, i.ToString());
                if (ret < 0) {
                    var insert = ~ret;
                    if (insert == 0) {
                        Assert.True(a.Length == 0 || a[0] > find);
                    } else if (insert >= a.Length) {
                        Assert.True(a[a.Length-1] < find);
                    } else {
                        Assert.True(a[insert-1] < find && a[insert] > find);
                    }
                }
            }


            
        }
    }
}
