# OldPhonePad – C# Coding Challenge

This repository contains my solution to the **C# Coding Challenge** for the
Technical Support Engineer role at Iron Software.

The task is to implement an `OldPhonePad` method that converts keypad button
presses on an old mobile phone into the correct text output.

---



## 🚀 Problem Description

Old phones used multi-press keypads:

- Press `2` → A  
- Press `22` → B  
- Press `222` → C  

Pressing the same key repeatedly cycles through its letters.



### Special Rules

| Key | Meaning |
|-----|---------|
| `*` | Backspace (delete last character or cancel current sequence) |
| ` ` (space) | Pause (commit current sequence) |
| `#` | Send/Finish (end of input) |



Example:

- **OldPhonePad.Core** → Business logic (`OldPhonePadConverter`)
- **OldPhonePad.App** → Console application for manual testing
- **OldPhonePad.Tests** → xUnit test suite

---

## ▶️ How to Run

### Build:

```bash
dotnet build


Run demo app:
cd src/OldPhonePad.App
dotnet run


Example input:

4433555 555666#




Output:

HELLO

🧪 Running Tests
cd tests/OldPhonePad.Tests
dotnet test


Expected:

Passed! ✔
