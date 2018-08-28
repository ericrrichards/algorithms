using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms {
    public static class BinarySearchExtensions {
        public static int BinarySearchRecursive(this int[] a, int find, int min=-1, int max = -1) {
            // Fixup default parameters
            if (min == -1 && max == -1) {
                min = 0;
                max = a.Length;
            }
            if (min >= max) {
                return -1;
            }
            var mid = min / 2 + max / 2 + (min & max & 1);
            if (a[mid] == find) {
                return mid;
            }
            return a[mid] > find 
                ? a.BinarySearchRecursive(find, min, mid-1) 
                : a.BinarySearchRecursive(find, mid+1, max);
        }

        public static int BinarySearchImperative(this int[] a, int find) {
            var min = 0;
            var max = a.Length;
            while (min < max) {
                var mid = min / 2 + max / 2 + (min & max & 1);
                if (a[mid] == find) {
                    return mid;
                }
                if (a[mid] > find) {
                    max = mid - 1;
                    continue;
                }
                min = mid + 1;
            }
            return -1;
        }

        public static int BinarySearch<T>(this T[] a, T find) where T: IComparable<T> {
            return BinarySearch(a, find, 0, a.Length);
        }

        public static int BinarySearch<T>(this T[] a, T find, int min, int max) where T : IComparable<T> {
            var lo = min;
            var hi = min + max - 1;
            while (lo <= hi) {
                var mid = lo + (hi-lo)/2;
                var c = a[mid].CompareTo(find);
                if (c == 0) {
                    return mid;
                }
                if (c > 0) {
                    hi = mid - 1;
                    continue;
                }
                lo = mid + 1;
            }
            return ~lo;
        }
    }
}
