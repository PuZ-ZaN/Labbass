# Labbass
Система лабораторных работ по физике

Команда разработки: Guardians Of Diploma 

---

### Формат системы
* Labbass - Десктопное приложение для компьютеров под управлением операционных систем Windows с поддержкой .NET Framework 4.7.2 


### Цель проекта
* Labbass призван упростить работу с виртуальными лабораторными работами


### Описание системы 
* Labbas - система управления лабораторными работами, разработанными специально для неё. Приложение LabbassCentral выступает агрегатором и единым клиентом запуска лабораторных работ, а так же система предоставляет свой API в виде labbascore.dll как свободно распространяемой библиотеки, позволяющей любому желающему возможность разработать свою лабораторную работу для системы Labbas


### Целевая Аудитория
* Система Labbass разрабатывается специально для УрФУ, соответственно ЦА данной системы - студенты вышеназванного ВУЗа


### Почему Labbas?
* Основное преимущество системы Labbass заключается в почти полном отсутствии ограничений при разработке лабораторных работ для неё, а так же в куда большем удобстве использования студентами, в сравнении с Flash лаб. работами, каждая из которых является независимым приложением. 

---
## Стек Технологий
### Общие:
  * Язык C#
  * .NET Framework 4.7.2
### LabbassCentral:
  * Microsoft WPF 
### Демонстрационная лабораторная работа:
  * Windows Forms
  * Spire PDF Library for .NET Framework
  * Control.Draggable Library for WinForms

---
## Работа с системой 
### Разработчик:
  * Ваш проект должен использовать [labbascore.dll](no_link) в соответствии с [документацией labbascore](no_link)
### Пользователь:
  * Для установки лабораторной работы поместите основной .dll лабораторной работы, а так же все зависимые файлы в одну папку внутри директории ./Labs/
  * Для запуска лабораторной работы запустите LabbassCentral.exe, в списке выберите нужную лабораторную работу и нажмите на неё ЛКМ.
  * Наслаждайтесь =)

---
## Системные требования
### LabbasCentral:
* ОС Windows 10 32-bit 
* .NET Framework 4.7.2 или выше, соответствующий .NET Standard 2.0

### Лабораторные работы
* СТ демонстрационной работы соответсвуют СТ LabbassCentral 
* СТ требования других лабораторных работ могут отличаться от СТ LabbassCentral и демонстрационной работы
---
## Установка 
* Скачать архив с последним релизом Labbass со [страницы выпусков GitHub](https://github.com/PuZ-ZaN/Labbass/releases)
* Распаковать архив
* Установить нужные лабораторные работы в соответствии с инструкцией выше 
    * Обратите внимание на соответствие версии ядра labbascore.dll и работ, которые вы устанавливаете.

--- 
## Структура приложения
* тут_должна_быть_картинка_но_я_хз_как_её_вставить
