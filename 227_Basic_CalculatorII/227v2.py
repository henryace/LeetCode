from collections import deque

def calculate(s: str) -> int:
    nums = deque([])
    ops = deque([])

    ord_0 = ord('0')
    ord_9 = ord('9')
    num = 0.0
    prev_op = None
    for c in s:
        if ord_0 <= ord(c) <= ord_9:  # num
            num = 10 * num + float(c)
        elif c in '+-*/':
            # print(nums, num, prev_op, c)
            if not (prev_op):
                nums.append(num)
            else:
                if prev_op == '+':
                    nums.append(num)
                elif prev_op == '-':
                    nums.append(-num)
                elif prev_op == '*':
                    nums.append(nums.pop() * num)
                elif prev_op == '/':
                    nums.append(int(nums.pop() / num))

            prev_op = c
            num = 0

    if prev_op == '+':
        nums.append(num)
    elif prev_op == '-':
        nums.append(-num)
    elif prev_op == '*':
        nums.append(nums.pop() * num)
    elif prev_op == '/':
        nums.append(int(nums.pop() / num))
    else:
        return int(s)
    return int(sum(nums)) # sum all numbers

#print( calculate("30+2*2"))
#print( calculate(" 3/2 "))
print( calculate(" 3+5 / 2 "))
print(calculate("14-3/2"))