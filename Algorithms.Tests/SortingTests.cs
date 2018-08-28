using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests {
    [TestFixture]
    public partial class SortingTests {
        public static string DebugSort<T>(IEnumerable<T> input, IEnumerable<T> sorted, IEnumerable<T> expected) {
            var inputStr = input.Aggregate(string.Empty, (s, i) => s + i + ", ");
            var sortedStr = sorted.Aggregate(string.Empty, (s, i) => s + i + ", ");
            var expectedStr = expected.Aggregate(string.Empty, (s, i) => s + i + ", ");
            return $"Input: {inputStr}\r\nSorted: {sortedStr}\r\nExpected: {expectedStr}";
        }
    }
}