# BazisGUI для Linux x64

Комплект включает Avalonia-приложение, .NET 8, Linux-библиотеки SkiaSharp,
HarfBuzzSharp и SQLite, Gmsh 4.13.1 (`libgmsh.so`) и адаптированный `GmshApi`.
Windows DLL Gmsh в этот комплект не входит.

## Запуск

Распакуйте архив в доступную для записи папку:

```bash
tar -xzf linux-x64-bundle.tar.gz
cd BazisGUI
./check-dependencies.sh
./start-bazis.sh
```

Скрипт запуска задаёт `BazisMeshPath` и `LD_LIBRARY_PATH` для текущего процесса.
Существующий `BazisMeshPath` имеет приоритет. Для запуска прямо из папки,
скопированной с Windows без архива, сначала выполните:

```bash
chmod +x BazisAvaloniaGUI start-bazis.sh check-dependencies.sh
```

## Системные зависимости

Нужна Linux x64 с glibc, графической сессией X11/XWayland и драйвером OpenGL,
поддерживающим compatibility profile 3.3 или 4.6. Alpine/musl и ARM не являются
целевыми платформами этого комплекта.

Для Ubuntu 22.04/24.04 и Debian 12 базовый набор:

```bash
sudo apt-get update
sudo apt-get install libx11-6 libice6 libsm6 libfontconfig1 libgl1 libglu1-mesa \
    libxrender1 libxcursor1 libxfixes3 libxft2 libxinerama1 libgomp1 \
    libstdc++6 libgcc-s1 zlib1g libgssapi-krb5-2 ca-certificates tzdata
```

Также нужны ICU и OpenSSL из репозитория выбранного дистрибутива: например,
`libicu72 libssl3` в Debian 12, `libicu70 libssl3` в Ubuntu 22.04,
`libicu74 libssl3t64` в Ubuntu 24.04. Точный список отсутствующих нативных
зависимостей выводит `check-dependencies.sh`. Необязательный провайдер трассировки
.NET LTTng исключён из этой проверки; для включения трассировки отдельно нужна
совместимая `liblttng-ust.so.0`. Системные glibc, драйверы и
графический сервер не поставляются в архиве.

## Повторная сборка на Windows

Нужны PowerShell 7.4+, .NET SDK 8 или новее, `tar`, доступ к NuGet и исходники
`GmshApi` из соседнего репозитория `CoreSolution` (включая ключ подписи).

```powershell
pwsh -File deployment/linux/Publish-Linux.ps1
```

По умолчанию результат: `artifacts/linux-x64-bundle` и
`artifacts/linux-x64-bundle.tar.gz`. Существующая папка не перезаписывается;
для следующей сборки укажите `-OutputDirectory artifacts/linux-x64-bundle-next`.
Путь к исходникам можно передать через `-GmshApiSourceDirectory`.

Скрипт скачивает официальный SDK с https://gmsh.info/bin/Linux/ и проверяет
закреплённый SHA-256. Обёртка пересобирается из существующих исходников с
сохранением подписанной идентичности `GmshApi 3.2.1.0`: загрузчик использует
`NativeLibrary`, а `gmshModelOccAddCircleArc` получает параметр `center=1`,
обязательный в ABI поставляемой версии. Исходный репозиторий не изменяется.
После обновления GmshApi необходимо пересмотреть эти две адаптации.

Системные требования Avalonia: https://docs.avaloniaui.net/docs/deployment/linux.

Лицензия Gmsh и сведения о поставке находятся в `licenses/gmsh`.
Источник Gmsh: https://gmsh.info/src/gmsh-4.13.1-source.tgz.

## Что проверить на целевой машине

Сборка на Windows не подтверждает работу приложения на Linux. Проверьте запуск,
лицензию, базы материалов/функций, открытие и сохранение проекта, импорт STEP,
создание геометрии (включая дуги), сетку и 3D-сцену. Проверка `ldd` подтверждает
только разрешение нативных зависимостей, а не выполнение всех функций приложения.
