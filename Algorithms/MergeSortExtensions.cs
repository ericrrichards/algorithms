using System;

namespace Algorithms {
    public static class MergeSortExtensions {
        #region integer mergesort with sentinel values
        public static void MergeSort(this int[] a) {
            a.MergeSort(0, a.Length - 1);
        }

        private static void MergeSort(this int[] a, int min, int max) {
            if (min < max) {
                var mid = (min + max) / 2; // *naive way of finding the median*
                a.MergeSort(min, mid);
                a.MergeSort(mid + 1, max);
                a.Merge(min, mid, max);
            }
        }

        private static void Merge(this int[] a, int min, int mid, int max) {
            // calculate the size of the left and right subarrays
            var lSize = mid - min + 1;
            var rSize = max - mid;
            // create the left and right subarrays
            var left = new int[lSize + 1];
            var right = new int[rSize + 1];
            // set sentinel values
            left[lSize] = int.MaxValue;
            right[rSize] = int.MaxValue;
            // populate the subarrays
            int leftIndex;
            int rightIndex;
            for (leftIndex = 0; leftIndex < lSize; leftIndex++) {
                left[leftIndex] = a[min + leftIndex];
            }

            for (rightIndex = 0; rightIndex < rSize; rightIndex++) {
                right[rightIndex] = a[mid + rightIndex + 1];
            }

            // merge the left and right subarrays back into the original array
            leftIndex = 0;
            rightIndex = 0;
            for (var i = min; i <= max; i++) {
                if (left[leftIndex] < right[rightIndex]) {
                    a[i] = left[leftIndex];
                    leftIndex++;
                } else {
                    a[i] = right[rightIndex];
                    rightIndex++;
                }
            }
        }
        #endregion


        #region Generic mergesort without sentinels
        public static void MergeSort<T>(this T[] a) where T : IComparable<T> {
            a.MergeSort(0, a.Length - 1);
        }

        private static void MergeSort<T>(this T[] a, int min, int max) where T : IComparable<T> {
            if (min < max) {
                var mid = min / 2 + max / 2 + (min & max & 1); // *slightly more sophisticated way of finding the median for very large sets*
                a.MergeSort(min, mid);
                a.MergeSort(mid + 1, max);
                a.Merge(min, mid, max);
            }
        }

        private static void Merge<T>(this T[] a, int min, int mid, int max) where T : IComparable<T> {
            var lSize = mid - min + 1;
            var rSize = max - mid;
            var left = new T[lSize];
            var right = new T[rSize];
            int leftIndex;
            int rightIndex;
            for (leftIndex = 0; leftIndex < lSize; leftIndex++) {
                left[leftIndex] = a[min + leftIndex];
            }

            for (rightIndex = 0; rightIndex < rSize; rightIndex++) {
                right[rightIndex] = a[mid + rightIndex + 1];
            }


            leftIndex = 0;
            rightIndex = 0;
            for (var i = min; i <= max; i++) {
                if (leftIndex < lSize && rightIndex < rSize && left[leftIndex].CompareTo(right[rightIndex]) < 0 || leftIndex < lSize && rightIndex >= rSize) {
                    a[i] = left[leftIndex];
                    leftIndex++;
                } else if (rightIndex < rSize) {
                    a[i] = right[rightIndex];
                    rightIndex++;
                }
            }
        }
        #endregion
    }

}