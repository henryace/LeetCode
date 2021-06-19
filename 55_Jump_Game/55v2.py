from collections import deque


def calculate(nums) -> int:
    if (len(nums) == 1): return True
    if nums[0] == 0 and len(nums) > 1: return False

    farestPoint = 1
    for i in range(len(nums) - 1):
        if nums[i] > 0 and (i<=farestPoint):
            farestPoint = (i + nums[i]) if (i + nums[i]) > farestPoint else farestPoint

    if (farestPoint >= (len(nums) - 1)):
        ans = True
    else:
        ans = False
    return ans


print(calculate([3, 2, 1, 0, 4]))
print(calculate([0]))
print( calculate([1,0,1,0]))
print(calculate([3,0,8,2,0,0,1]))
