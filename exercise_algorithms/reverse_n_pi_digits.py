import math
from validation_input import validate_input_int


def reverse_n_pi_digits(n: int) -> str:
    # my idea is to convert the pi number to string
    # much easier to work with indexes
    pi_str = str(math.pi).replace('.', '')
    n_first_pi_digits = pi_str[0:n]
    return n_first_pi_digits[::-1]


n = validate_input_int("enter number of pi digits to display reversed: ")
print(f"the {n} numbers of pi reversed: " + reverse_n_pi_digits(n))
