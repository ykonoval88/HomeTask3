|                Method |     Mean |     Error |   StdDev |   Median |
|---------------------- |---------:|----------:|---------:|---------:|
|    UnionOperationTest | 256.9 ms | 12.806 ms | 37.76 ms | 256.2 ms |
| UnionAllOperationTest | 229.4 ms |  8.098 ms | 23.75 ms | 223.1 ms |

Summary

The execution of Union took more time, because additional operation to exclude duplication added to UNION algorithm.

In all UNION operations for current program a merge sort used.
