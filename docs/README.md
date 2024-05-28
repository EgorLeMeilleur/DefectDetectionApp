# Defect Detection App

## Обзор

Это приложение предназначено для обнаружения дефектов на изображениях, отображения результатов и управления данными о дефектах с использованием базы данных SQLite. 
Оно включает в себя скрипт на Python для выполнения инференса с использованием алгоритма YOLO.

## Требования

- .NET Core SDK с пакетами pythonnet, Newtonsoft.json, System.Data.Sqlite
- Python 3.x с библиотекой ultralytics, cv2, json, numpy
- IDE (Visual Studio или Visual Studio Code)

## Запуск проекта без установки приложения

1. Склонировать репозиторий
    ```sh
    git clone https://github.com/egorlemeilleur/DefectDetectionApp.git
    ```
2. Откройте проект (пример для Visual Studio):
    ```sh
    cd src/DefectDetectionApp
    start DefectDetectionApp.sln
    ```
3. Установите NuGet packages: pythonnet, Newtonsoft.json, System.Data.Sqlite
4. Соберите решение
5. В каталоге bin/Debug создайте виртуальное окружение myenv, скопируйте файлы yolo_inference.py, yolov8n.pt, requirements.txt из каталога src/model в каталог bin/Debug и установите библиотеки из requirements.txt
5. Запустите решение

## Установка приложения
Для установки необходим только установленный Python 3.x 
1. Скачайте установщик с [releases page](https://github.com/egorlemeilleur/DefectDetectionApp/releases)
2. Запустите файл `DefectDetectionAppInstaller.exe` и следуйте инструкциям. Завершение установки может занять много времени, так как устанавливаются необходимые библиотеки в venv
3. Запустите файл `DefectDetectionApp.exe` в папке установки

## Использование приложения

1. Нажмите на кнопку "Загрузить новый файл" для выбора файла для детекции
3. Нажмите на кнопку "Найти дефекты на изображении" для запуска детекции
4. Нажмите на кнопку "Посмотреть сохранённые детекции" для просмотра информации обо всех выполненных вами детекциях
5. Нажмите на кнопку "Удалить все данные о детекциях" для удаления данных