# Контрольная точка №14 — record и record struct

## Вариант 1. Person / PersonStruct
1. `public record Person(string Name, int Age);`
2. Созданы два экземпляра `Person` с одинаковыми значениями, продемонстрировано, что `==` возвращает `true`.
3. Использовано `with`-выражение для создания копии с другим `Age`, доказано, что оригинал не изменился.
4. Выполнена деконструкция `Person` в переменные `name` и `age`.
5. Объявлен `public record struct PersonStruct(string Name, int Age);`, продемонстрировано прямое изменение свойства `Age` (`personStruct.Age = 30;`).

## Вариант 2. Vector3 / Vector3Struct
1. `public record Vector3(double X, double Y, double Z)` с вычисляемым свойством `Length`.
2. Созданы два экземпляра `Vector3` с одинаковыми координатами, продемонстрировано, что `==` возвращает `true`.
3. Использовано `with`-выражение для создания копии с изменённым `Z`, подтверждён перерасчёт `Length` для копии.
4. Выполнена деконструкция `Vector3` в переменные `x, y, z`.
5. Объявлен `public record struct Vector3Struct(double X, double Y, double Z)`, продемонстрировано прямое изменение свойства `X`.