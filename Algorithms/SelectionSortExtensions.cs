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
        /// <summary>
        /// Recursive selection sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <param name="index"></param>
        public static void SelectionSortRec<T>(this T[] a, int n=0, int index = 0) where T : IComparable<T> {
            int MinIndex<T>(T[] array, int i, int j) where T : IComparable<T>{
                if (i == j) {
                    return i;
                }
                var k = MinIndex(array, i + 1, j);
                return (array[i].CompareTo(array[k]) <0) ? i : k;
            }

            if (n == 0) {
                n = a.Length;
            }
            if (index == n) {
                return;
            }
            var min = MinIndex(a, index, n - 1);
            if (min != index) {
                var temp = a[min];
                a[min] = a[index];
                a[index] = temp;
            }
            a.SelectionSortRec(n, index+1);
        }

    }
}
