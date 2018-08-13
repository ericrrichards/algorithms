using System;

namespace Algorithms {
    public static class MergeSortExtensions {
        public static void MergeSort(this int[] a) {
            a.MergeSort(0, a.Length - 1);
        }

        private static void MergeSort(this int[] a, int min, int max) {
            if (min < max) {
                var mid = (min + max) / 2;
                a.MergeSort(min, mid);
                a.MergeSort(mid + 1, max);
                a.Merge(min, mid, max);
            }
        }

        private static void Merge(this int[] a, int min, int mid, int max) {
            var n1 = mid - min + 1;
            var n2 = max - mid;
            var left = new int[n1 + 1];
            var right = new int[n2 + 1];
            // set sentinel values
            left[n1] = int.MaxValue;
            right[n2] = int.MaxValue;
            int leftIndex;
            int rightIndex;
            for (leftIndex = 0; leftIndex < n1; leftIndex++) {
                left[leftIndex] = a[min + leftIndex];
            }

            for (rightIndex = 0; rightIndex < n2; rightIndex++) {
                right[rightIndex] = a[mid + rightIndex + 1];
            }

            
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
        public static void MergeSort<T>(this T[] a) where T:IComparable<T> {
            a.MergeSort(0, a.Length - 1);
        }

        private static void MergeSort<T>(this T[] a, int min, int max) where T : IComparable<T> {
            if (min < max) {
                var mid = (min + max) / 2;
                a.MergeSort(min, mid);
                a.MergeSort(mid + 1, max);
                a.Merge(min, mid, max);
            }
        }

        private static void Merge<T>(this T[] a, int min, int mid, int max) where T : IComparable<T> {
            var n1 = mid - min + 1;
            var n2 = max - mid;
            var left = new T[n1];
            var right = new T[n2];
            int leftIndex;
            int rightIndex;
            for (leftIndex = 0; leftIndex < n1; leftIndex++) {
                left[leftIndex] = a[min + leftIndex];
            }

            for (rightIndex = 0; rightIndex < n2; rightIndex++) {
                right[rightIndex] = a[mid + rightIndex + 1];
            }


            leftIndex = 0;
            rightIndex = 0;
            for (var i = min; i <= max; i++) {
                if (leftIndex < n1 && rightIndex < n2 && left[leftIndex].CompareTo(right[rightIndex]) < 0 || leftIndex < n1 && rightIndex >= n2) {
                    a[i] = left[leftIndex];
                    leftIndex++;
                } else if (rightIndex < n2) {
                    a[i] = right[rightIndex];
                    rightIndex++;
                }
            }
        }
    }
}