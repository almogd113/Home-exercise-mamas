import math
from validation_input import validate_input_int


def pythagorean_triplet_by_sum(my_sum: int) -> None:
    a = 0
    b = 0
    c = 0
    # we have 3 numbers to get the sum, and they are supposed to fulfill the following condition:
    # a < b < c
    # worst case:
    # a - because we have three numbers a must be smaller than sum / 3 - 1
    # a max is sum / 3 -1
    # these limits exist when a is max
    # b - should be smaller than sum / 3 + 1
    # b max is sum / 3
    # c - should be greater than sum / 3 and  to fulfill sum - a - b
    # c min is sum / 3 + 1
    check_any_answers = False
    for a in range(int(my_sum / 3)):
        for b in range(a + 1, int(my_sum / 3 + 1)):
            c = my_sum - a - b
            check_pythagoras = math.pow(a, 2) + math.pow(b, 2) == math.pow(c, 2)
            if check_pythagoras:
                check_any_answers = True
                pythagorean_triplet = f"{a} < {b} < {c}"
                print(pythagorean_triplet)

    if not check_any_answers:
        print("There are no Pythagorean triples for this sum")


sum_to_check = validate_input_int("enter sum to get Pythagorean triples: ")
pythagorean_triplet_by_sum(sum_to_check)
