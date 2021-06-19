def calculate(s):
    """
    :type s: str
    :rtype: int
    """
    numbers = []
    currentNum = 0
    operator = '+'
    i = 0

    while (i < len(s)):
        if s[i] == ' ':
            i+=1
            continue

        while ((i < len(s) and s[i].isdigit())):
            currentNum = currentNum * 10 + ord(s[i]) - ord('0')
            i+=1

        if operator in '+-':
            numbers.append(currentNum * (1 if operator == '+' else -1))

        elif operator == '*':
            numbers[-1] *= currentNum

        elif operator == '/':
            sign = -1 if numbers[-1] < 0 or currentNum < 0 else 1
            numbers[-1] = abs(numbers[-1]) // abs(currentNum) * sign
            #-3 // 2 =-2

        currentNum = 0
        if ( (i < len(s) ) ) :
            #print(s[i])
            operator = s[i]
            print(s[i], operator)

        i+=1

    return sum(numbers)

print( calculate("30+2*2"))
print( calculate(" 3/2 "))

print( calculate("  30"))
print( calculate(" 3+5 / 2 "))
print(calculate("14-3/2"))