using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests {
    public partial class SortingTests {
        [TestFixture]
        public class SelectionSort {
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            public void Sort(int[] input, int[] expected) {
                var sorted = input.ToArray();
                sorted.SelectionSort();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, TestName = "In Order")]
            [TestCase(new[] { 2, 3, 1 }, new[] { 1, 2, 3 }, TestName = "Out of Order")]
            public void SortRec(int[] input, int[] expected) {
                var sorted = input.ToArray();
                sorted.SelectionSortRec();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1f, 2f, 3f }, new[] { 1f, 2f, 3f }, TestName = "In Order")]
            [TestCase(new[] { 2f, 3f, 1f }, new[] { 1f, 2f, 3f }, TestName = "Out of Order")]
            public void Sort(float[] input, float[] expected) {
                var sorted = input.ToArray();
                sorted.SelectionSort();
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1f, 2f, 3f }, new[] { 1f, 2f, 3f }, TestName = "In Order")]
            [TestCase(new[] { 2f, 3f, 1f }, new[] { 1f, 2f, 3f }, TestName = "Out of Order")]
            public void SortComp(float[] input, float[] expected) {
                var sorted = input.ToArray();
                sorted.SelectionSort(Comparer<float>.Default);
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
            [TestCase(new[] { 1f, 2f, 3f }, new[] { 1f, 2f, 3f }, TestName = "In Order")]
            [TestCase(new[] { 2f, 3f, 1f }, new[] { 1f, 2f, 3f }, TestName = "Out of Order")]
            public void SortFunc(float[] input, float[] expected) {
                var sorted = input.ToArray();
                sorted.SelectionSort((f, f1) => f < f1);
                Assert.True(sorted.SequenceEqual(expected), DebugSort(input, sorted, expected));
            }
        }
    }
}