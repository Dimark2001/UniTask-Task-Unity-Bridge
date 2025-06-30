Unity Async Bridge
Overview
Унифицированный интерфейс для асинхронных операций в Unity, поддерживающий как стандартные Task, так и UniTask с автоматическим выбором реализации в зависимости от платформы.

Key Features
Кросс-платформенная работа (включая WebGL через UniTask)

Поддержка отмены операций через CancellationToken

Единый интерфейс для await-паттерна

Централизованная обработка ошибок

Core Components
IAsyncOperation Interface
Базовый интерфейс асинхронной операции с методами:

IsCompleted - проверка завершения

OnCompleted - регистрация продолжения

GetResult - получение результата

Cancel - отмена операции

AsyncOperationBase
Абстрактный базовый класс, реализующий:

Механизм отмены через CancellationTokenSource

Хранение состояния выполнения

Базовую логику продолжений

Platform Implementations
TaskAsyncOperation - реализация для стандартных Task

UniTaskAsyncOperation - реализация для UniTask (WebGL)

AsyncOperationFactory
Фабрика для создания экземпляров с автоматическим выбором реализации:

Определяет платформу через директивы компиляции

Предоставляет единую точку создания операций

Platform Support
Платформа	Реализация
WebGL	UniTask
Все другие	Стандартный Task
Requirements
Unity 2020.3+

UniTask (только для WebGL-сборок)
