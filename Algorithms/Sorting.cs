using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms {
    public static class Sorting {
        public static void InsertionSort(this int[] a) {
            for (var j = 1; j < a.Length; j++) {
                var key = a[j];
                var i = j - 1;
                while (i >= 0 && a[i] > key) {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }
        }
        public static int[] InsertionSorted(int[] a) {
            var ret = a.ToArray();
            ret.InsertionSort();
            return ret;
        }

        public static void InsertionSort<T>(this T[] a) where T: IComparable<T> {
            for (var j = 1; j < a.Length; j++) {
                var key = a[j];
                var i = j - 1;
                while (i >= 0 && a[i].CompareTo(key) > 0) {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }
        }
        public static T[] InsertionSorted<T>(T[] a) where T : IComparable<T> {
            var ret = a.ToArray();
            ret.InsertionSort();
            return ret;
        }
    }

    [TestFixture]
    public class SortingTests {
        public static string DebugSort<T>(IEnumerable<T> input, IEnumerable<T> sorted, IEnumerable<T> expected) {
            var inputStr = input.Aggregate(string.Empty, (s, i) => s + i + ", ");
            var sortedStr = sorted.Aggregate(string.Empty, (s, i) => s + i + ", ");
            var expectedStr = expected.Aggregate(string.Empty, (s, i) => s + i + ", ");
            return $"Input: {inputStr}\r\nSorted: {sortedStr}\r\nExpected: {expectedStr}";
        }

        public class InsertionSort {
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            public void Sort(int[] input, int[] expected) {
                var sorted = Sorting.InsertionSorted(input);
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input,sorted, expected));
            }
        }
    }
}
