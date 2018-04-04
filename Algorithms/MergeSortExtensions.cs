using System;

namespace Algorithms {
    public static class MergeSortExtensions {
        public static void MergeSort(this int[] a) {
            a.MergeSort(0, a.Length - 1);
        }

        private static void MergeSort(this int[] a, int p, int r) {
            if (p < r) {
                var q = (p + r) / 2;
                a.MergeSort(p, q);
                a.MergeSort(q + 1, r);
                a.Merge(p, q, r);
            }
        }

        private static void Merge(this int[] a, int p, int q, int r) {
            var n1 = q - p + 1;
            var n2 = r - q;
            var left = new int[n1 + 1];
            var right = new int[n2 + 1];
            left[n1] = int.MaxValue;
            right[n2] = int.MaxValue;
            int i;
            int j;
            for (i = 0; i < n1; i++) {
                left[i] = a[p + i];
            }

            for (j = 0; j < n2; j++) {
                right[j] = a[q + j + 1];
            }

            
            i = 0;
            j = 0;
            for (var k = p; k <= r; k++) {
                if (left[i] < right[j]) {
                    a[k] = left[i];
                    i++;
                } else {
                    a[k] = right[j];
                    j++;
                }
            }
        }
        public static void MergeSort<T>(this T[] a) where T:IComparable<T> {
            a.MergeSort(0, a.Length - 1);
        }

        private static void MergeSort<T>(this T[] a, int p, int r) where T : IComparable<T> {
            if (p < r) {
                var q = (p + r) / 2;
                a.MergeSort(p, q);
                a.MergeSort(q + 1, r);
                a.Merge(p, q, r);
            }
        }

        private static void Merge<T>(this T[] a, int p, int q, int r) where T : IComparable<T> {
            var n1 = q - p + 1;
            var n2 = r - q;
            var left = new T[n1];
            var right = new T[n2];
            int i;
            int j;
            for (i = 0; i < n1; i++) {
                left[i] = a[p + i];
            }

            for (j = 0; j < n2; j++) {
                right[j] = a[q + j + 1];
            }


            i = 0;
            j = 0;
            for (var k = p; k <= r; k++) {
                if (i < n1 && j < n2 && left[i].CompareTo(right[j]) < 0 || i < n1 && j >= n2) {
                    a[k] = left[i];
                    i++;
                } else if (j < n2) {
                    a[k] = right[j];
                    j++;
                }
            }
        }
    }
}