# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #3 выполнил(а):
- Холстинин Егор Алесеевич
- РИ-220943
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.
- ✨Magic ✨

## Цель работы
Разработать оптимальный баланс для десяти уровней игры Dragon Picker

## Задание 1
### Предложите вариант изменения найденных переменных для 10 уровней в игре. Визуализируйте изменение уровня сложности в таблице. 
Ход работы:
- При анализе проекта на юнити я нашел следующий набор переменных, которые можно изменить и которые могут повлиять на сложность игры.

![image](https://github.com/Yrwlcm/DA-in-GameDev-lab3/assets/99079920/a644f0d3-aa79-400e-839b-16da8f9dd3a4)

- Из них я решил изменять только 3 переменные в зависимости от сложности:
	- Скорость дракона
	- Границы его перемещения
	- Время между появлением яиц
 - Я решил не менять шанс изменить направление движения дракона, так как оно неочевидно влияет на сложность.
 - Исходя из этого я заполнил таблицу для балансировки сложности.
 - ![image](https://github.com/Yrwlcm/DA-in-GameDev-lab3/assets/99079920/5ac6dc36-7556-4753-939c-e5116cfd6e47)
(ссылка на таблицу: https://docs.google.com/spreadsheets/d/1rGUgMVTxPI102JsdLLZYqU_4sxbSlgoUpDoOgzGH05w/edit#gid=0)

## Задание 2
### Создайте 10 сцен на Unity с изменяющимся уровнем сложности.

- Далее я создал 10 сцен на юнити меняя эти переменные вручную в соответствии с таблицей для балансировки.
![image](https://github.com/Yrwlcm/DA-in-GameDev-lab3/assets/99079920/0b37ea2f-6d33-4c46-88f1-12db2248f155)


## Задание 3
### Решение в 80+ баллов должно заполнять google-таблицу данными из Python. В Python данные также должны быть визуализированы.

- Пользуясь знаниями из [2 лабораторной работы](https://github.com/Yrwlcm/DA-in-GameDev-lab2) я написал python скрипт который заполняет таблицу балансировки в соответствии с функциями, которые описывают рост переменных. А также строит графики переменных.

```py
import gspread
import numpy as np
import matplotlib.pyplot as plt

gc = gspread.service_account(filename='unitydatascience-400712-fb36790122ff.json')
sh = gc.open("Week#3 - Баланс в играх")
speed = 4
borders = 10
time_between_drops = 2.0
chance_change_direction = 1

speed_data = []
borders_data = []
time_data = []
chance_data = []

for i in range(3, 18):
    # Крайне удобный аргумент value_input_option='USER_ENTERED'
    # Позволяет не приводить данные к строкам, а писать как есть
    sh.sheet1.update(('B' + str(i)), speed, value_input_option='USER_ENTERED')
    sh.sheet1.update(('C' + str(i)), f'{chance_change_direction}%',
                     value_input_option='USER_ENTERED')
    sh.sheet1.update(('D' + str(i)), borders, value_input_option='USER_ENTERED')
    sh.sheet1.update(('E' + str(i)), round(time_between_drops, 1),
                     value_input_option='USER_ENTERED')
    print(speed, borders, time_between_drops, chance_change_direction)

    speed_data.append(speed)
    borders_data.append(borders)
    time_data.append(time_between_drops)
    chance_data.append(chance_change_direction)

    speed += 2
    borders += 1
    time_between_drops -= 0.1

plt.figure(figsize=(8, 8))
x = list(range(1, 16))

plt.plot(x, speed_data, label='Скорость')
plt.plot(x, borders_data, label='Границы')
plt.plot(x, time_data, label='Время между яйцами')
plt.plot(x, chance_data, label='Шанс изменить положение')

plt.legend()
plt.show()

```

- Результатом работы скрипта является вывод в консоль данных, которые он записал в гугл-таблицу. А так же их графики.
![image](https://github.com/Yrwlcm/DA-in-GameDev-lab3/assets/99079920/5371e65c-7e6a-40b8-833f-6b5aa0e3e823)


## Выводы

В результате данной лабораторной работы я научился оптимизировать переменные в играх с помощью таблицы для балансировки. Также я закрепил свои знания по работе с заполнением гугл-таблиц с помощью python скриптов.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
