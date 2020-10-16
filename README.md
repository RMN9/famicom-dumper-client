# famicom-dumper-client
Клиентский модуль для Famicom Dumper/Programmer (by Cluster)


Формат использования приложения из командной строки: 
<b>FamicomDumper.exe \<command\> [options] </b>

Для примера <b>FamicomDumper.exe --help </b> вызывает отображение встроенной справки по командам с описанием.

Ниже приведен список только самых основных команд для работы с картриджем. По части Coolboy смотрите во встроенную справку через --help.

Проверка картриджа после сборки (многоигровочка by Cluster):

<b>--test-coolgirl</b> -> Тест памяти PRG и CHR  <br>

<b>--test-prg-ram-coolgirl</b> -> Тест отдельно для PRG

<b>--test-chr-ram-coolgirl</b> -> Тест отдельно для CHR

<b>--test-bads-coolgirl</b> -> Тест flash памяти

Запись картриджа после пройденных тестов:

<b>FamicomDumper.exe write-coolgirl -f multirom.unf --check</b>

<b>write-coolgirl</b> -> Записать

<b>-f</b> -> указанный файл

<b>multirom.unf</b> -> имя файла на запись

<b>--check</b> -> выполнить CRC контроль по завершении записи
