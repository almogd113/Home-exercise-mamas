import re

RED = '\033[31m'
RESET = '\033[0m'


def is_float(user_number: str) -> bool:
    try:
        float(user_number)
        return True
    except ValueError:
        print(f'Could not except {user_number} as number')
        return False


def validate_input(prompt: str) -> float:
    while True:
        user_number = input(prompt)
        updated_number_dot = user_number.replace('.', '', 1)
        updated_number_minus = updated_number_dot.replace('-', '', 1)
        if updated_number_minus.isdigit():
            if is_float(user_number):
                return float(user_number)
        print(f'Could not except {user_number} as number')

        continue
