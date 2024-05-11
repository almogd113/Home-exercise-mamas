def is_int(number: str) -> bool:
    try:
        int(number)
        return True
    except ValueError:
        print(f'Could not convert {number} to int')
        return False


def validate_input_int(prompt: str) -> int:
    while True:
        user_number = input(prompt)
        if not is_int(user_number):
            continue
        return int(user_number)


def is_float(user_number: str) -> bool:
    try:
        float(user_number)
        return True
    except ValueError:
        print(f'Could not except {user_number} as number')
        return False


def validate_input_float(prompt: str) -> float:
    while True:
        user_number = input(prompt)
        updated_number_dot = user_number.replace('.', '', 1)
        updated_number_minus = updated_number_dot.replace('-', '', 1)
        if updated_number_minus.isdigit():
            if is_float(user_number):
                return float(user_number)
        print(f'Could not except {user_number} as number')

        continue
