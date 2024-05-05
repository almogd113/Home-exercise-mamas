import statistics
import sys
import matplotlib

matplotlib.use('TkAgg')

import matplotlib.pyplot as plt
import numpy as np
from input import validate_input
from typing import List


def get_user_numbers() -> [float]:
    user_number = validate_input("enter number please: ")
    numbers_list: [float] = [List[float]]
    while float(user_number) != -1:
        numbers_list.append(user_number)
        user_number = validate_input("enter number please: ")
    return numbers_list


def calculate_average(numbers: List[float]) -> float:
    return statistics.mean(numbers)


def count_positive_numbers(numbers: List[float]) -> int:
    return len(list(filter(lambda item: item > 0, numbers)))


def sort_numbers_ascending_order(numbers: List[float]) -> [float]:
    numbers.sort(reverse=False)
    return numbers


def plot_diagram(numbers: List[float]) -> None:
    points = np.array(numbers)
    # naming the x axis
    plt.xlabel('x - axis')
    # naming the y axis
    plt.ylabel('y - axis')
    plt.plot(points, points, 'o')
    plt.show()

    # Two  lines to make our compiler able to draw:
    plt.savefig(sys.stdout.buffer)
    sys.stdout.flush()


lst = sort_numbers_ascending_order([1.9, 2, 3, -1])
for i in lst:
    print(i)

plot_diagram([1.9, 2, 3, -1])
