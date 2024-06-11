﻿### Задание
Разработать API для трекера задач, который позволяет пользователям регистрироваться, добавлять задачи и получать аналитическую информацию о своей производительности.

### Требования
1. Модели данных:
    - TaskItem: задача.
      - Поля: название, описание, приоритет(низкий, средний, высокий), срок выполнения.
    - TaskRecord: запись о выполненной задаче.
      - Поля: пользователь(ForeignKey), задача(ForeignKey на User), задача(ForeignKey на TaskItem), дата выполнения, затраченное время в минутах.
2. API эндпоинты:
    - CRUD для TaskItem:
      - Создание: POST /api/task/
      - Просмотр списка: GET /api/task/
      - Просмотр одной задачи: GET /api/task/{id}/
      - Обновление: PUT /api/task/{id}/
      - Удаление: DELETE /api/task/{id}/
    - CRUD для TaskRecord
      - Создание: POST /api/task-record/
      - Просмотр списка: GET /api/task-record/
      - Просмотр одной записи: GET /api/task-record/{id}/
      - Обновление: PUT /api/task-record/{id}/
      - Удаление: DELETE /api/task-record/{id}/
    - Аналалитика: 
      - Ежедневная сводка: GET /api/summary/daily/
        - Возвращает информацию о выполненных задачах, затраченном времени и распределении по приоритетам за текущий день.
        - Предусмотрены фильтр по любому дню
3. Дополнительные требования:
    - Использовать JWT аутентификацию
    - Реализовать разрешения, чтобы пользователи могли управлять только своими записями о выполненных задачах.
4. Будет плюсом: 
    - Документация API (Swagger).
    - Наличие тестов.
    - Dockerfile для запуска приложения в контейнере.
    - Наличие комментариев в коде.