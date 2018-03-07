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

        public static void InsertionSort<T>(this T[] a) where T : IComparable<T> {
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
        public static void InsertionSort<T>(this T[] a, IComparer<T> comparer) {
            for (var j = 1; j < a.Length; j++) {
                var key = a[j];
                var i = j - 1;
                while (i >= 0 && comparer.Compare(a[i], key) > 0) {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }
        }
        public static void InsertionSort<T>(this T[] a, Func<T, T, bool> greaterThan) {
            for (var j = 1; j < a.Length; j++) {
                var key = a[j];
                var i = j - 1;
                while (i >= 0 && greaterThan(a[i], key)) {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }
        }

        public static void InsertionSortRec<T>(this T[] a, int n = 0) where T : IComparable<T> {
            if (n == 0) { // allows calling without specifying the length
                n = a.Length;
            }
            if (n == 1) {
                return;
            }
            a.InsertionSortRec(n - 1);
            var key = a[n - 1];
            var i = ShuffleRight(a, n - 2, key);

            a[i + 1] = key;

            int ShuffleRight(T[] a1, int p, T key1) {
                if (p < 0 || a1[p].CompareTo(key1) <= 0) {
                    return p;
                }
                a1[p + 1] = a1[p];
                return ShuffleRight(a1, p - 1, key1);
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
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            [TestCase(new[] { 10, 6, 12, 4, 1 }, new[] { 1, 4, 6, 10, 12 }, TestName = "Card Example")]
            public void SortInPlace(int[] input, int[] expected) {
                var sorted = input;
                input.InsertionSort();
                Assert.True(sorted.SequenceEqual(expected));
            }
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            [TestCase(new[] { 2, 3 }, new[] { 2, 3 }, TestName = "Two elements")]
            [TestCase(new[] { 1 }, new[] { 1 }, TestName = "One element")]
            [TestCase(new[] { 10, 6, 12, 4, 1 }, new[] { 1, 4, 6, 10, 12 }, TestName = "Card Example")]
            public void SortInPlaceRec(int[] input, int[] expected) {
                var sorted = input.ToArray();
                sorted.InsertionSortRec();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            [TestCase(new[] { 10, 6, 12, 4, 1 }, new[] { 1, 4, 6, 10, 12 }, TestName = "Card Example")]
            public void SortInPlaceFunc(int[] input, int[] expected) {
                var sorted = input;
                input.InsertionSort((a, b) => a > b);
                Assert.True(sorted.SequenceEqual(expected));
            }
            [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 3, 2, 1 }, TestName = "Out of Order")]
            [TestCase(new[] { 10, 6, 12, 4, 1 }, new[] { 12, 10, 6, 4, 1 }, TestName = "Card Example")]
            public void SortInPlaceFuncDesc(int[] input, int[] expected) {
                var sorted = input;
                input.InsertionSort((a, b) => a < b);
                Assert.True(sorted.SequenceEqual(expected));
            }
        }
    }
}
