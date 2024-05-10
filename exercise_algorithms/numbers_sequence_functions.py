import statistics
import sys
import matplotlib

matplotlib.use('TkAgg')

import matplotlib.pyplot as plt
import numpy as np
from input import validate_input
from typing import List
from scipy.stats import pearsonr


def get_user_numbers() -> [float]:
    user_number = validate_input("enter number please: ")
    numbers_list: [float] = []
    while user_number != -1:
        numbers_list.append(user_number)
        user_number = validate_input("enter number please: ")
    return numbers_list


def calculate_average(numbers: List[float]) -> float:
    return statistics.mean(numbers)


def count_positive_numbers(numbers: List[float]) -> int:
    return len(list(filter(lambda item: item > 0, numbers)))


def sort_numbers_ascending_order(numbers: List[float]) -> [float]:
    # numbers.sort(reverse=False)
    numbers = sorted(numbers, key=lambda number: number, reverse=False)
    return numbers


def plot_diagram(numbers: List[float]) -> None:
    pointsy = np.array(numbers)
    pointsx = np.array([i for i in range(len(numbers))])
    # naming the x axis
    plt.xlabel('numbers order')
    # naming the y axis
    plt.ylabel('number value')
    plt.plot(pointsx, pointsy, 'o')
    pearsonr_result = pearsonr(x=pointsx, y=pointsy)
    print("correlation: " + str(pearsonr_result[0]))
    plt.show()

    # Two  lines to make our compiler able to draw:
    plt.savefig(sys.stdout.buffer)
    sys.stdout.flush()


print("numbers list: ")
numbers_lst: [float] = get_user_numbers()
print("the numbers are")
print(numbers_lst)
print("--------------------------")
numbers_average = calculate_average(numbers_lst)
counter_positive_numbers = count_positive_numbers(numbers_lst)
sorted_numbers_lst = sort_numbers_ascending_order(numbers_lst)
print("average calculation: " + str(numbers_average))
print("counter positive numbers: " + str(counter_positive_numbers))
print("sorted numbers list: ")
print(sorted_numbers_lst)
plot_diagram(numbers_lst)