using System;

namespace KT_14_Records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("   Контрольная точка №14: record и record struct  ");
            Console.WriteLine("==================================================\n");

            RunVariant1_Person();
            Console.WriteLine("\n--------------------------------------------------\n");
            RunVariant2_Vector3();

            Console.WriteLine("\nРабота программы успешно завершена!");
        }

        #region Вариант 1. Person / PersonStruct

        static void RunVariant1_Person()
        {
            Console.WriteLine("=== ВАРИАНТ 1: Person / PersonStruct ===\n");

            Console.WriteLine("1. Создание экземпляров Person:");
            string name = ReadStringFromConsole("Введите имя: ");
            int age = ReadIntFromConsole("Введите возраст: ");

            var person1 = new Person(name, age);
            var person2 = new Person(name, age);

            Console.WriteLine($"\nperson1: {person1}");
            Console.WriteLine($"person2: {person2}");
            Console.WriteLine($"Проверка равенства (person1 == person2): {person1 == person2}");

            Console.WriteLine("\n2. Изменение возраста через 'with':");
            int newAge = ReadIntFromConsole("Введите новый возраст для копии: ");
            var personCopy = person1 with { Age = newAge };

            Console.WriteLine($"Оригинал (person1): {person1}");
            Console.WriteLine($"Копия с новым Age (personCopy): {personCopy}");
            Console.WriteLine($"Доказательство: оригинал не изменился (Age == {person1.Age})");

            Console.WriteLine("\n3. Деконструкция Person:");
            var (decName, decAge) = person1;
            Console.WriteLine($"Деконструировано -> Имя: {decName}, Возраст: {decAge}");

            Console.WriteLine("\n4. Демонстрация record struct (PersonStruct):");
            var personStruct = new PersonStruct(name, age);
            Console.WriteLine($"До изменения: {personStruct}");

            int directAge = ReadIntFromConsole("Введите новый возраст для прямого присвоения в record struct: ");
            personStruct.Age = directAge;
            Console.WriteLine($"После прямого изменения (personStruct.Age = {directAge}): {personStruct}");
        }

        #endregion

        #region Вариант 2. Vector3 / Vector3Struct

        static void RunVariant2_Vector3()
        {
            Console.WriteLine("=== ВАРИАНТ 2: Vector3 / Vector3Struct ===\n");

            Console.WriteLine("1. Создание экземпляров Vector3:");
            double x = ReadDoubleFromConsole("Введите X: ");
            double y = ReadDoubleFromConsole("Введите Y: ");
            double z = ReadDoubleFromConsole("Введите Z: ");

            var v1 = new Vector3(x, y, z);
            var v2 = new Vector3(x, y, z);

            Console.WriteLine($"\nv1: {v1}, Length = {v1.Length:F2}");
            Console.WriteLine($"v2: {v2}, Length = {v2.Length:F2}");
            Console.WriteLine($"Проверка равенства (v1 == v2): {v1 == v2}");

            Console.WriteLine("\n2. Изменение координаты Z через 'with':");
            double newZ = ReadDoubleFromConsole("Введите новое значение Z для копии: ");
            var vCopy = v1 with { Z = newZ };

            Console.WriteLine($"Оригинал (v1): {v1}, Length = {v1.Length:F2}");
            Console.WriteLine($"Копия (vCopy): {vCopy}, Length = {vCopy.Length:F2}");
            Console.WriteLine("Доказательство: оригинал не изменился, Length копии пересчитан.");

            Console.WriteLine("\n3. Деконструкция Vector3:");
            var (decX, decY, decZ) = v1;
            Console.WriteLine($"Деконструировано -> x: {decX}, y: {decY}, z: {decZ}");

            Console.WriteLine("\n4. Демонстрация record struct (Vector3Struct):");
            var vStruct = new Vector3Struct(x, y, z);
            Console.WriteLine($"До изменения: {vStruct}");

            double directX = ReadDoubleFromConsole("Введите новое значение X для прямого изменения в record struct: ");
            vStruct.X = directX;
            Console.WriteLine($"После прямого изменения (vStruct.X = {directX}): {vStruct}");
        }

        #endregion

        #region Методы безопасного ввода с перехватом исключений

        static string ReadStringFromConsole(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Строка не может быть пустой!");
                    }

                    return input.Trim();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Ошибка ввода]: {ex.Message} Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка]: {ex.Message} Попробуйте снова.");
                }
            }
        }

        static int ReadIntFromConsole(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Ввод не может быть пустым!");
                    }

                    if (!int.TryParse(input, out int result))
                    {
                        throw new FormatException($"Значение '{input}' не является целым числом.");
                    }

                    if (result < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(result), "Число не может быть отрицательным.");
                    }

                    return result;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"[Ошибка формата]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"[Ошибка диапозона]: {ex.ParamName} — {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Ошибка ввода]: {ex.Message} Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Неизвестная ошибка]: {ex.Message} Попробуйте снова.");
                }
            }
        }

        static double ReadDoubleFromConsole(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Replace(',', '.');

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Ввод не может быть пустым!");
                    }

                    if (!double.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double result))
                    {
                        throw new FormatException($"Значение '{input}' не является действительным числом.");
                    }

                    return result;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"[Ошибка формата]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Ошибка ввода]: {ex.Message} Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Неизвестная ошибка]: {ex.Message} Попробуйте снова.");
                }
            }
        }

        #endregion
    }
}