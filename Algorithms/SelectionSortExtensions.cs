using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms {
    public static class SelectionSortExtensions {
        public static void SelectionSort(this int[] a) {
            for (var i = 0; i < a.Length-1; i++) {
                var smallest = a[i];
                var smallestI = i;
                for (var j = i+1; j < a.Length; j++) {
                    if (a[j] < smallest) {
                        smallest = a[j];
                        smallestI = j;
                    }
                }

                a[smallestI] = a[i];
                a[i] = smallest;
            }
        }
        public static void SelectionSort<T>(this T[] a) where T:IComparable<T> {
            for (var i = 0; i < a.Length - 1; i++) {
                var smallest = a[i];
                var smallestI = i;
                for (var j = i + 1; j < a.Length; j++) {
                    if (a[j].CompareTo(smallest) < 0) {
                        smallest = a[j];
                        smallestI = j;
                    }
                }

                a[smallestI] = a[i];
                a[i] = smallest;
            }
        }
        public static void SelectionSort<T>(this T[] a, IComparer<T> comparer)  {
            for (var i = 0; i < a.Length - 1; i++) {
                var smallest = a[i];
                var smallestI = i;
                for (var j = i + 1; j < a.Length; j++) {
                    if (comparer.Compare(a[j], smallest) < 0) {
                        smallest = a[j];
                        smallestI = j;
                    }
                }

                a[smallestI] = a[i];
                a[i] = smallest;
            }
        }
        public static void SelectionSort<T>(this T[] a, Func<T, T, bool> lessThan) {
            for (var i = 0; i < a.Length - 1; i++) {
                var smallest = a[i];
                var smallestI = i;
                for (var j = i + 1; j < a.Length; j++) {
                    if (lessThan(a[j], smallest)) {
                        smallest = a[j];
                        smallestI = j;
                    }
                }

                a[smallestI] = a[i];
                a[i] = smallest;
            }
        }

    }
}
