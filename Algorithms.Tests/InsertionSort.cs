using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests {
    public partial class SortingTests {
        [TestFixture]
        public class InsertionSort {
            [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, TestName = "In Order")]
            [TestCase(new[] {2, 3, 1}, new[] {1, 2, 3}, TestName = "Out of Order")]
            public void Sort(int[] input, int[] expected) {
                var sorted = InsertionSortExtensions.InsertionSorted(input);
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }

            [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, TestName = "In Order")]
            [TestCase(new[] {2, 3, 1}, new[] {1, 2, 3}, TestName = "Out of Order")]
            [TestCase(new[] {10, 6, 12, 4, 1}, new[] {1, 4, 6, 10, 12}, TestName = "Card Example")]
            public void SortInPlace(int[] input, int[] expected) {
                var sorted = input;
                input.InsertionSort();
                Assert.True(sorted.SequenceEqual(expected));
            }
            [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, TestName = "In Order")]
            [TestCase(new[] {2, 3, 1}, new[] {1, 2, 3}, TestName = "Out of Order")]
            [TestCase(new[] {10, 6, 12, 4, 1}, new[] {1, 4, 6, 10, 12}, TestName = "Card Example")]
            public void SortInPlaceBinary(int[] input, int[] expected) {
                var sorted = input.ToArray();
                sorted.InsertionSortBinary();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }

            [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, TestName = "In Order")]
            [TestCase(new[] {2, 3, 1}, new[] {1, 2, 3}, TestName = "Out of Order")]
            [TestCase(new[] {2, 3}, new[] {2, 3}, TestName = "Two elements")]
            [TestCase(new[] {1}, new[] {1}, TestName = "One element")]
            [TestCase(new[] {10, 6, 12, 4, 1}, new[] {1, 4, 6, 10, 12}, TestName = "Card Example")]
            public void SortInPlaceRec(int[] input, int[] expected) {
                var sorted = input.ToArray();
                sorted.InsertionSortRec();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }

            [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, TestName = "In Order")]
            [TestCase(new[] {2, 3, 1}, new[] {1, 2, 3}, TestName = "Out of Order")]
            [TestCase(new[] {10, 6, 12, 4, 1}, new[] {1, 4, 6, 10, 12}, TestName = "Card Example")]
            public void SortInPlaceFunc(int[] input, int[] expected) {
                var sorted = input;
                input.InsertionSort((a, b) => a > b);
                Assert.True(sorted.SequenceEqual(expected));
            }

            [TestCase(new[] {1, 2, 3}, new[] {3, 2, 1}, TestName = "In Order")]
            [TestCase(new[] {2, 3, 1}, new[] {3, 2, 1}, TestName = "Out of Order")]
            [TestCase(new[] {10, 6, 12, 4, 1}, new[] {12, 10, 6, 4, 1}, TestName = "Card Example")]
            public void SortInPlaceFuncDesc(int[] input, int[] expected) {
                var sorted = input;
                input.InsertionSort((a, b) => a < b);
                Assert.True(sorted.SequenceEqual(expected));
            }
        }
    }
}