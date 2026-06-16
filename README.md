# 🏭 Industrial HMI Simulator

> WPF + MVVM 기반 산업용 HMI(Human Machine Interface) 시뮬레이터

실시간으로 생성되는 센서 데이터를 모니터링하고 장비 운전 상태를 시뮬레이션할 수 있는 WPF 기반 산업용 HMI(Human Machine Interface) 프로그램입니다.

---

## 📌 프로젝트 소개

산업 현장에서 사용하는 HMI 화면을 참고하여 제작한 프로젝트입니다.

장비의 상태를 실시간으로 모니터링하고, 센서 데이터를 표시하며, 운전/정지/비상정지 기능과 로그 관리 기능을 구현했습니다.

실제 PLC와 연결되어 있지는 않으며 SensorService를 통해 온도 및 압력 센서 데이터를 시뮬레이션하며, 실시간으로 UI와 로그에 반영되도록 구현했습니다.

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

<img width="1093" height="645" alt="image" src="https://github.com/user-attachments/assets/c758748f-0703-403f-a17a-c088ef2e248d" />


<img width="1092" height="641" alt="image" src="https://github.com/user-attachments/assets/58e10718-c42e-4a55-925b-7cde6adc29e1" />


* 장비 시작(Start)
* 장비 정지(Stop)
* 비상 정지(Emergency Stop)
* 장비 상태 초기화(Reset)

---



### ✅ 장비 상태 표시

- 장비 상태 텍스트 출력
- 상태 표시 LED

| 상태 | 표시 |
|-------------|-----|
| RUN         | 🟢 |
| STOP        | ⚪ |
| EMERGENCY   | 🔴 |

---

### ✅ 로그 시스템

* 장비 이벤트 로그 생성
* 시간 기록
* 상태 기록
* 온도 기록
* 압력 기록
* 메시지 기록

<img width="1099" height="638" alt="image" src="https://github.com/user-attachments/assets/b3f859dc-d5ff-41e2-a364-9c8e7bee9084" />


---

### ✅ 로그 저장

* JSON 파일 저장
* System.Text.Json 사용


<img width="1102" height="645" alt="image" src="https://github.com/user-attachments/assets/8687dda5-c857-498a-89ca-32bf401a97a8" />
로그 저장 버튼을 누르면 
logs라는 이름의 파일에 json 형식 로그 데이터 저장

<img width="398" height="575" alt="image" src="https://github.com/user-attachments/assets/cdf73db2-35ff-4d68-a518-8bda8587c080" />


---

### ✅ 실시간 센서 모니터링




<img width="1096" height="643" alt="image" src="https://github.com/user-attachments/assets/31c650ce-08e2-4d62-b40e-ecb5ecae8204" />


* Temperature 표시
* Pressure 표시
* DispatcherTimer를 이용한 실시간 데이터 갱신
* SensorService를 통한 센서 데이터 시뮬레이션



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


📖 배운 점

이번 프로젝트를 통해 단순히 UI를 구현하는 것에서 그치지 않고, WPF 애플리케이션을 MVVM 패턴으로 설계하는 방법을 익혔습니다.

특히 View, ViewModel, Service를 역할에 따라 분리함으로써 각 계층의 책임을 명확히 나누는 설계의 중요성을 이해할 수 있었습니다. 이러한 구조는 기능 수정 시 다른 계층에 미치는 영향을 최소화하여 유지보수와 기능 확장에 유리하며, 각 기능을 독립적으로 검증하기 쉬운 구조라는 점도 배울 수 있었습니다.

또한 DispatcherTimer와 ObservableCollection을 활용하여 실시간으로 변경되는 데이터를 UI에 자동으로 반영하는 데이터 바인딩 방식을 구현하며 WPF의 이벤트 처리와 데이터 흐름을 이해할 수 있었습니다.

Dependency Injection을 적용하여 SensorService와 JsonService를 분리함으로써 객체 간의 결합도를 낮추고, 서비스의 역할을 명확하게 분리하는 설계 방식을 경험했습니다.

마지막으로 JSON 직렬화를 이용해 로그 데이터를 파일로 저장하는 기능을 구현하면서 데이터 관리와 서비스 계층 분리에 대한 이해를 높일 수 있었습니다.
