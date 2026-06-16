# 🏭 Industrial HMI Simulator

> WPF + MVVM 기반 산업용 HMI(Human Machine Interface) 시뮬레이터

실시간 센서 데이터를 모니터링하고 장비를 제어할 수 있는 산업용 HMI 프로그램입니다.

---

## 📷 Preview

> (실행 화면 GIF 또는 스크린샷 추가)

---

## 📌 프로젝트 소개

산업 현장에서 사용하는 HMI 화면을 참고하여 제작한 프로젝트입니다.

장비의 상태를 실시간으로 모니터링하고, 센서 데이터를 표시하며, 운전/정지/비상정지 기능과 로그 관리 기능을 구현했습니다.

실제 PLC와 연결되어 있지는 않으며 SensorService를 통해 센서 데이터를 시뮬레이션합니다.

---

## 🛠 개발 환경

* Visual Studio 2022
* .NET 8
* C#
* WPF
* WPF UI
* MVVM Toolkit

---

## ✨ 주요 기능

### ✅ 장비 제어

* 장비 시작(Start)
* 장비 정지(Stop)
* 비상 정지(Emergency Stop)
* 장비 상태 초기화(Reset)

---

### ✅ 실시간 센서 모니터링

* Temperature 표시
* Pressure 표시
* DispatcherTimer를 이용한 실시간 데이터 갱신
* SensorService를 통한 센서 데이터 시뮬레이션

---

### ✅ 장비 상태 표시

* 장비 상태 텍스트 출력
* 상태 표시 LED

| 상태        | 표시 |
| --------- | -- |
| RUN       | 🟢 |
| STOP      | ⚪  |
| EMERGENCY | 🔴 |

---

### ✅ 로그 시스템

* 장비 이벤트 로그 생성
* 시간 기록
* 상태 기록
* 온도 기록
* 압력 기록
* 메시지 기록

---

### ✅ 로그 저장

* JSON 파일 저장
* System.Text.Json 사용
* 사람이 읽기 쉬운(Indented) 형태 저장

예시

```json
[
  {
    "Time": "2026-06-15T15:10:02",
    "Type": "RUN",
    "Temperature": 24,
    "Pressure": 1012,
    "Message": "장비 시작"
  }
]
```

---

### ✅ 데이터 모니터링

DataGrid를 이용하여

* 시간
* 상태
* 온도
* 압력
* 메시지

를 실시간으로 확인할 수 있습니다.

---

## 🏗 프로젝트 구조

```
Pratice

├── Models
│   └── LogEntry
│
├── Services
│   ├── SensorService
│   └── JsonService
│
├── ViewModels
│   ├── DashboardViewModel
│   └── DataViewModel
│
├── Views
│   ├── DashboardPage
│   └── DataPage
│
└── App.xaml
```

---

## 📚 적용한 기술

* MVVM Pattern
* Dependency Injection
* ObservableCollection
* CommunityToolkit.Mvvm
* ICommand
* DispatcherTimer
* Data Binding
* JSON Serialization
* DataGrid
* Navigation

---

## 🚀 향후 개선 예정

* PLC 통신(Modbus/TCP)
* SQLite 로그 저장
* CSV Export
* 알람 이력 관리
* 실시간 그래프
* 사용자 권한 관리

---

## 📖 배운 점

이번 프로젝트를 통해

* MVVM 구조 설계
* WPF 데이터 바인딩
* DispatcherTimer를 이용한 실시간 UI 갱신
* ObservableCollection을 이용한 데이터 관리
* JSON 직렬화
* 서비스 분리 및 DI 적용

등을 경험할 수 있었습니다.
