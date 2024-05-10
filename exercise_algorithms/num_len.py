import math


def num_len(number: int) -> int:
    # log10 gives as the result of the number of
    # digits we have in each number besides the last digit
    # for example every number that is smaller than 10 would give as a result of 0
    # because there is no presumption where base 10 can be a single-digit number
    # that's why + 1 is neede

    return int(math.log10(number) + 1)


print(num_len(1))
