def check_type_order(order_descending: bool, my_part_str: str) -> bool:
    # create a sorted version of this string
    sorted_version = [my_part_str[index] for index in range(len(my_part_str))]
    sorted_version.sort(reverse=order_descending)

    # check equality between the versions
    return get_bool_equal_strings(my_part_str, sorted_version)


def check_type_order_2(order_descending: bool, my_part_str: str) -> bool:
    sorted_version = sorted(my_part_str, reverse=order_descending)
    # check equality between the versions
    return get_bool_equal_strings(my_part_str, sorted_version)


def get_bool_equal_strings(my_part_str: str, sorted_version: []) -> bool:
    length = len(my_part_str)
    for index in range(length):
        if sorted_version[index] != my_part_str[index]:
            return False
    return True


def is_sorted_polyndrom(my_str: str) -> bool:
    # checking palindrome with ASCII code
    # each of half of the word should be in a sorted way
    # the first half - in ascending order
    # the second half - in descending order

    # check if str is palindrome
    last_index = len(my_str) - 1
    for index in range(int(len(my_str) / 2)):
        if not my_str[index] == my_str[last_index - index]:
            return False

    # check orders
    first_half = my_str[0:int(len(my_str) / 2) + 1:1]
    check_first_half_order = check_type_order(order_descending=False, my_part_str=first_half)
    second_half = my_str[int(len(my_str) / 2): len(my_str): 1]
    check_second_half_order = check_type_order(order_descending=True, my_part_str=second_half)

    return check_second_half_order and check_first_half_order


# print(is_sorted_polyndrom("aba"))
string_to_check_palindrome = input("enter word to check sorted palindrome: ")
print(is_sorted_polyndrom(string_to_check_palindrome))
