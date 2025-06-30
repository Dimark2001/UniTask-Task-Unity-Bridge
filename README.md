# Unity Async Bridge
**Unified Task/UniTask Operations for Cross-Platform Unity Projects**  

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)  
![Unity Version](https://img.shields.io/badge/Unity-2020.3+-black.svg)  

## Table of Contents
1. [Overview](#overview)  
2. [Installation](#installation)  
   - [Dependencies](#dependencies)  
   - [Manual Setup](#manual-setup)  
3. [Usage](#usage)  
   - [Basic Async Operation](#1-basic-async-operation)  
   - [Cancellable Service](#2-cancellable-service)  
4. [API Reference](#api-reference)  
5. [Platform Notes](#platform-notes)  
6. [License](#license)  

## Overview
Lightweight abstraction layer for seamless async operations in Unity, supporting both **Task (C#)** and **UniTask (Cysharp)** with automatic platform detection.  

Key Features:  
✔ WebGL support (via UniTask)  
✔ Cancellation support  
✔ Unified error handling  
✔ Awaitable interface  

## Installation

### Dependencies
- **[UniTask](https://github.com/Cysharp/UniTask)** (Required for WebGL):  
  ```sh
  # Install via UPM
  https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
