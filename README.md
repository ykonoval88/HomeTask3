|                Method |          Job |       Jit | Platform |     Mean |    Error |    StdDev |   Median |      Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|---------------------- |------------- |---------- |--------- |---------:|---------:|----------:|---------:|-----------:|----------:|----------:|----------:|
|    UnionOperationTest | LegacyJitX86 | LegacyJit |      X86 | 190.2 ms | 5.052 ms | 14.575 ms | 189.0 ms | 52333.3333 | 2000.0000 | 1000.0000 |  178.2 MB |
| UnionAllOperationTest | LegacyJitX86 | LegacyJit |      X86 | 178.3 ms | 3.877 ms |  4.616 ms | 176.8 ms | 52333.3333 | 2333.3333 | 1000.0000 | 178.16 MB |
|    UnionOperationTest |    RyuJitX64 |    RyuJit |      X64 | 196.3 ms | 7.225 ms | 20.379 ms | 192.2 ms | 75000.0000 | 4333.3333 |  666.6667 | 256.48 MB |
| UnionAllOperationTest |    RyuJitX64 |    RyuJit |      X64 | 175.1 ms | 3.686 ms | 10.276 ms | 171.3 ms | 74000.0000 | 2333.3333 |  666.6667 | 256.41 MB |

Summary

The execution of Union took more time, because additional operation to exclude duplication added to UNION algorithm.

In UNION operation for current program a merge sorting used.
