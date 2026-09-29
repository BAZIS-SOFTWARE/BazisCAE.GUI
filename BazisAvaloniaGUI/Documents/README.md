# Диаграммы BazisAvaloniaGUI

Пакеты на всех диаграммах названы по правилу «проект. сущность». Каждая сущность описана полностью на одной диаграмме; на остальных она показана свёрнуто со стереотипом `<<boundary>>`.

| Диаграмма | Что на ней |
| --- | --- |
| `ДК. Scene.Avalonia.Detail.mdpuml` | 3D-сцена, `SceneCore` (сжато), `ProjectSession` и `ResultsSession`, связь с `ProjectController`, `CondView` и `ISceneTools` |
| `ДК. MainWindow.Avalonia.mdpuml` | главное окно, `MainWindowViewModel`, главное меню по группам и пунктам, сервисы оболочки (`MessageLog`, `AppSettings`, `IDialogService`, `IOperationRunner`, `IUiDispatcher`, `ILicenseService`) |
| `ДК. Panels.Avalonia.mdpuml` | навигатор (модель узлов, построитель дерева), панель свойств (`ActiveItem`, `IPropertySource`, строки и значения), консоль (реестр команд, разбор строки) |

PNG рядом с каждым исходником — визуализация актуального исходника (PlantUML 1.2025.4).

Пояснения к исходной схеме сцены — [scene.avalonia.md](../../GUI/Documents/scene.avalonia.md), к отображению условий — [CondView.md](../../GUI/Documents/CondView.md).
