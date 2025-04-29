# Event Driven Framework

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Ein leichtgewichtiges, plattformübergreifendes und erweiterbares Event-Driven-Framework für .NET, inspiriert von Best Practices des Xamarin/.NET MAUI Community Toolkits.

---

## ✨ Features

- 🧠 **Einfacher EventBus** zur Entkopplung von Sender und Empfänger
- 🎯 **Plattformunabhängig** – nutzbar in MAUI, Konsolen-Apps, WinUI u.v.m.
- ♻️ **Wiederverwendbare Komponenten**
- 🧪 **Getestet & modular** aufgebaut
- 📦 **Vorbereitung für NuGet-Publishing**
- 🔌 **Erweiterbar** durch Custom Events und Subsysteme

---

## 🏗 Projektstruktur

```plaintext
event-driven-framework/
├── src/                    # Kernbibliotheken (z. B. EventBus)
│   ├── EventDriven.Core/   # Basis-EventBus-Logik
│   └── EventDriven.Maui/   # MAUI-spezifische Erweiterungen (optional)
├── samples/                # Beispielprojekte
│   ├── SampleConsoleApp/   # Konsolenanwendung (Demo)
│   └── SampleMauiApp/      # .NET MAUI Beispiel (Demo)
├── tests/                  # Unit- und UI-Tests
├── docs/                   # Projektdokumentation
├── build/                  # Build- und CI-Skripte
└── README.md               # Dieses Dokument
```

---

## 📦 Schnellstart

### Voraussetzungen

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Für MAUI:
  - Visual Studio 2022+ mit .NET MAUI workload

### Konsolen-Demo ausführen

```bash
cd samples/SampleConsoleApp
dotnet run
```

### Eigene Events verwenden

```csharp
var bus = new EventBus();
bus.Subscribe<string>(msg => Console.WriteLine($"Empfangen: {msg}"));
bus.Publish("Hallo Welt!");
```

---

## 🧱 Architekturüberblick

- **Publisher** senden Events beliebigen Typs
- **Subscriber** registrieren sich für einen Typ von Event
- Alle Events werden synchron verarbeitet (optional erweiterbar für Async/Queued)

```plaintext
+-------------+         +-------------+
|  Publisher  |         |  Subscriber |
+-------------+         +-------------+
       │                        ▲
       └────[ EventBus ]────────┘
```

---

## 📁 Kernmodule

| Modul                  | Beschreibung |
|------------------------|--------------|
| `EventDriven.Core`     | Implementierung des EventBus |
| `EventDriven.Maui`     | Optional: MAUI-spezifische Hooks |
| `SampleConsoleApp`     | Minimalbeispiel zur Nutzung |
| `SampleMauiApp`        | Beispiel mit UI |

---

## 🔬 Tests

```bash
cd tests/EventDriven.Core.Tests
dotnet test
```

---

## 🤝 Beitrag leisten

Wir freuen uns über Beiträge! Lies dir bitte vorab die [CONTRIBUTING.md](CONTRIBUTING.md) und den [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) durch.

Typische Beiträge:
- Fehler melden
- Features vorschlagen
- Code verbessern
- Dokumentation erweitern

---

## 📜 Lizenz

Dieses Projekt steht unter der [MIT-Lizenz](LICENSE).

---

## 🌐 Links

- [Offizielles Repository](https://github.com/rudolfstepan/event-driven-framework)
- [Fragen? Issues? → Hier entlang](https://github.com/rudolfstepan/event-driven-framework/issues)

---

> Erstellt mit ❤️ und Architekturverstand von [@rudolfstepan](https://github.com/rudolfstepan)
