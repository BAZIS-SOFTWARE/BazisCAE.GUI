# Консоль Avalonia

`ConsoleControl` — перенос `GUI/Console/ConsoleControl.cs` с теми же членами:
`PrintInfo`, `PrintHistory`, `ExecuteCmdFile`, `ProcessCommandLine`, `SetValue`,
`KeyDownEventHadler`, `ClearAll_Click`, `btnBackGroundInfo_Click`, `btnStartMacro_Click`,
`btnDictionary_Click`, событиями `ConsoleCommandEnteredEvent` и `CommandsListRequestedEvent`.
`ConsoleHistory`, `FieldsParser`, `Token` и перечисления `Enums/*` скопированы без изменений логики.

Обработка команд, как в WinForms, находится в оболочке: `Shell/Methods/Console/ExecuteCommand.cs`
и соседние файлы повторяют `GUI/Methods/Console/*` (имена методов, порядок операций, проверки).

Отличия, вызванные Avalonia:

- вместо `RichTextBox` вывод — список цветных строк `Messages`, ввод — отдельная строка `TextBox`;
  после Enter команда остаётся в выводе, как последняя строка `RichTextBox`;
- диалоги файлов и цвета асинхронные (`StorageProvider`, `ColorSelectionDialog`);
- `PrintInfo` из фонового потока передаётся в `Dispatcher.UIThread`;
- путь журнала собирается через `Path.Combine` (сборка также под Linux), ссылка на журнал
  открывается через `Launcher`.

Проверка: `dotnet test BazisAvaloniaGUI.Tests/BazisAvaloniaGUI.Tests.csproj -p:UsedAvaloniaProducts=`.
