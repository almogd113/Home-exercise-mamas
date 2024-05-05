import math


def reverse_n_pi_digits(n: int) -> str:
    # my idea is to convert the pi number to string
    # much easier to work with indexes
    pi_str = str(math.pi).replace('.', '')
    n_first_pi_digits = pi_str[0:n]
    return n_first_pi_digits[::-1]


print(reverse_n_pi_digits(3))
