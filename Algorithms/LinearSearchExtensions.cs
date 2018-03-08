using System;
using System.Collections.Generic;

namespace Algorithms {
    public static class LinearSearchExtensions {
        /// <summary>
        /// Simple integer linear search
        /// </summary>
        /// <param name="a">Array to search</param>
        /// <param name="find">value to find</param>
        /// <returns>Index of <see cref="find"/> in <see cref="a"/> or -1</returns>
        public static int LinearSearch(this int[] a, int find) {
            for (var i = 0; i < a.Length; i++) {
                if (a[i] == find) {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Generic linear search on IEquatables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">array to search</param>
        /// <param name="find">value to find</param>
        /// <returns>index in of <see cref="find"/> in <see cref="a"/> or -1</returns>
        public static int LinearSearch<T>(this T[] a, T find) where T:IEquatable<T> {
            for (var i = 0; i < a.Length; i++) {
                if (a[i].Equals(find)) {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Generic linear search using IEqualityComparer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">Array to search</param>
        /// <param name="find"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int LinearSeach<T>(this T[] a, T find, IEqualityComparer<T> comparer) {
            for (int i = 0; i < a.Length; i++) {
                if (comparer.Equals(a[i], find)) {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Generic linear search using an equality delegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">Array to search</param>
        /// <param name="find"></param>
        /// <param name="equals"></param>
        /// <returns></returns>
        public static int LinearSearch<T>(this T[] a, T find, Func<T, T, bool> equals) {
            for (int i = 0; i < a.Length; i++) {
                if (equals(a[i], find)) {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Recursive linear search
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="find"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int LinearSearchRec<T>(this T[] a, T find, int i=0) where T : IEquatable<T> {
            if (i == a.Length) {
                return -1;
            }
            if (!a[i].Equals(find)) {
                return a.LinearSearchRec(find, i + 1);
            }

            return i;
        }
    }
}