using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests {
    public partial class SortingTests {
        [TestFixture]
        public class MergeSort {
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            public void Sort(int[] input, int[] expected) {
                var sorted = input.ToArray();
                sorted.MergeSort();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1f, 2f, 3f }, new[] { 1f, 2f, 3f }, TestName = "In Order")]
            [TestCase(new[] { 2f, 3f, 1f }, new[] { 1f, 2f, 3f }, TestName = "Out of Order")]
            [TestCase(new[] { 2f, 7f, 3f, 5f, 1f, 4f, 6f }, new[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f }, TestName = "Out of Order 2")]
            public void Sort(float[] input, float[] expected) {
                var sorted = input.ToArray();
                sorted.MergeSort();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }

            [Test]
            public void MergeSort_Random() {
                var arraySize = 100;
                var rand = new Random();
                for (int i = 0; i < 100; i++) {
                    var l = new List<double>();
                    for (int j = 0; j < arraySize; j++) {
                        l.Add(rand.NextDouble()*100);
                    }

                    var a = l.ToArray();
                    a.MergeSort();
                    Assert.True(a.SequenceEqual(l.OrderBy(li=>li)));
                }
            }
            [Test]
            public void MergeSort2_Random() {
                var arraySize = 100;
                var rand = new Random();
                for (int i = 0; i < 100; i++) {
                    var l = new List<double>();
                    for (int j = 0; j < arraySize; j++) {
                        l.Add(rand.NextDouble()*100);
                    }

                    var a = l;
                    var sorted = a.MergeSort();
                    var expected = l.OrderBy(li=>li).ToList();
                    Assert.True(sorted.SequenceEqual(expected), DebugSort(a, sorted, expected));
                }
            }

/*
var a = new[] { 4, 6, 1, 3, 2 };
a.MergeSort()=> {
    a.MergeSort(0, 4) => { = cn
        a.MergeSort(0,2) => { = cn/2
            a.MergeSort(0,1) => { = cn/4
                a.MergeSort(0,0); = T(1) = c
                a.MergeSort(1,1); = T(1) = c
                a.Merge(0,0,1); = cn/2
            a.MergeSort(2,2); = T(1) = c
            a.Merge(0,1,2); = cn/2
        }
        a.MergeSort(3,4) => { = T(n/2)
            a.MergeSort(3,3); = T(1) = c
            a.MergeSort(4,4); = T(1) = c
            a.Merge(3,3,4); = cn/2
        }
        a.Merge(0, 2, 4); = cn
    }
}
*/
                
/*
    n = 4

    T(4)
    2T(2) + 4c
    2(2T(1) + 2c) + 4c
    2(2c) + 2c) + 4c
    4c + 2(2c) + 2c)
    4c + 4c + 4c

    T(4)
    T(2) + T(2) + 4c
    T(1) + T(1) + 2c + T(1) + T(1) + 2c + 4c
    c + c + 2c + c + c + 2c + 4c
    4(c) + 2(2c) + 4c


 */

        }
    }
}