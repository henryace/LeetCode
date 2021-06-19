from collections import deque


def calculate(nums) -> int:
    if len(nums) <= 1:
        return True

    DP = [False for _ in range(len(nums) + 1)]
    i, j = 0, nums[0]
    while i <= j and i < len(nums):
        if i > 0:
            j = max(j, i + nums[i])
        DP[i + 1] = True
        i += 1

    return DP[-1]


print(calculate([3, 2, 1, 0, 4]))
print(calculate([0]))
print( calculate([1,0,1,0]))
print(calculate([3,0,8,2,0,0,1]))
