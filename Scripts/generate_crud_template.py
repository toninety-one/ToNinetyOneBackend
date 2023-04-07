import os

import templates


def file_writer(text, path):
    with open(path, 'w') as f:
        f.write(text)


def generate_operation(operation_name: str, operation_type: str):
    operation = f"{operation_type}{operation_name}"

    folder_path = f".temp/{operation_name}/{operation}/"

    os.mkdir(folder_path)

    file_writer(str(templates.operations["command"]).replace("{0}", operation_name).replace("{1}", operation),
                f"{folder_path}{operation}Command.cs")

    file_writer(str(templates.operations["handler"]).replace("{0}", operation_name).replace("{1}", operation),
                f"{folder_path}{operation}CommandHandler.cs")

    file_writer(str(templates.operations["validator"]).replace("{0}", operation_name).replace("{1}", operation),
                f"{folder_path}{operation}CommandValidator.cs")

    file_writer(str(templates.operations["dto"]).replace("{0}", operation_name).replace("{1}", operation),
                f"{folder_path}{operation}Dto.cs")


def generate_folders(operation_name: str) -> int:
    if not os.path.exists(".temp"):
        os.mkdir(".temp")

    if os.path.exists(f".temp/{operation_name}"):
        return -1

    os.mkdir(f".temp/{operation_name}")

    generate_operation(operation_name, "Create")
    generate_operation(operation_name, "Update")
    generate_operation(operation_name, "Delete")


def main():
    name = input("Enter operation name: ")

    if name == "":
        print("Enter valid name")
        exit()

    result = generate_folders(name)

    if result == -1:
        print("folder exists")
        exit()


if __name__ == "__main__":
    main()
