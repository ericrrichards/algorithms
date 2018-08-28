using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms {
    public static class InsertionSortExtensions {
        /// <summary>
        /// Simple integer InsertionSort
        /// </summary>
        /// <param name="a">array to sort</param>
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
        /// <summary>
        /// Immutable insertion sort that returns a sorted copy
        /// </summary>
        /// <param name="a"></param>
        /// <returns>array to sort</returns>
        public static int[] InsertionSorted(int[] a) {
            var ret = a.ToArray();
            ret.InsertionSort();
            return ret;
        }
        /// <summary>
        /// Generic in-place InsertionSort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
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
        public static void InsertionSortBinary<T>(this T[] a) where T : IComparable<T> {
            for (var j = 1; j < a.Length; j++) {
                var key = a[j];
                var i = j - 1;

                var low = 0;
                var high = i;
                var mid = low / 2 + high / 2 + (low & high & 1);

                var loc = Find(a, key, 0, i);
                while (i >= loc ) {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }

            int Find(T[] array, T item, int low, int high) {
                if (high <= low) {
                    return item.CompareTo(array[low]) > 0 ? low + 1 : low;
                }
                var mid = low / 2 + high / 2 + (low & high & 1);
                if (item.CompareTo(array[mid])==0) {
                    return mid + 1;
                }
                if (item.CompareTo(array[mid]) > 0) {
                    return Find(array, item, mid + 1, high);
                }
                return Find(array, item, low, mid - 1);
            }
        }
        /// <summary>
        /// Generic immutable insertion sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">Array to sort</param>
        /// <returns></returns>
        public static T[] InsertionSorted<T>(T[] a) where T : IComparable<T> {
            var ret = a.ToArray();
            ret.InsertionSort();
            return ret;
        }
        /// <summary>
        /// Generic Insertion sort with a custom IComparer
        /// Doesn't require IComparable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">Array to sort</param>
        /// <param name="comparer">Comparer</param>
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
        /// <summary>
        /// Delegate generic insertion sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">Array to sort</param>
        /// <param name="greaterThan">Comparison predicate</param>
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
        /// <summary>
        /// Recursive insertion sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">Array to sort</param>
        /// <param name="n"></param>
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
    }
}
