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
        [TestCase(new[]{6, 10}, 12, 1)]
        public void FindInsertionPoint(int[] a, int find, int expectedPos) {
            var ret = a.BinarySearch(find, 0, 1);
            Assert.AreEqual(expectedPos, ~ret);
        }
    }
}
