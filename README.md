Royal Run

끝없이 생성되는 길 위에서 장애물을 피하고, 코인과 아이템을 먹으며 시간과 점수를 경쟁하는 3D 러너 게임.
A fast-paced 3D endless runner with procedural chunks, time checkpoints, pickups, and dynamic camera zoom.

<p align="center"> <a href="#demo">🎮 플레이 영상</a> • <a href="#features">✨ 주요 특징</a> • <a href="#tech-stack">🧰 기술 스택</a> • <a href="#setup">⚙️ 설치/실행</a> • <a href="#screenshots">🖼️ 스크린샷</a> </p> <p> <img alt="Unity" src="https://img.shields.io/badge/Unity-6.0-black?logo=unity"/> <img alt="Platform" src="https://img.shields.io/badge/Platform-Windows%20%7C%20macOS-blue"/> </p>
## TL;DR

* **장르**: 3D Endless Runner
* **엔진**: Unity 6.0
* **역할(Role)**: 기획 100%, 프로그래밍 100% (로우폴리 리소스 활용)
* **플레이 루프**: 달리기 → 장애물 회피 → 코인 수집(점수) → 체크포인트로 시간 연장 → 더 어려워지는 스폰 속도에 적응

<h2 id="demo">🎮 플레이 영상</h2>

* ▶️ **Gameplay Video**: 준비 중

> 속도가 높아질수록 카메라 FOV가 넓어지고, 체크포인트 통과 시 남은 시간이 연장됩니다.

<h2 id="features">✨ 주요 특징 / Features</h2>

* 🧱 **프로시저럴 청크(Chunk) 생성** — 3레인 기반 지형을 순차 스폰/파괴하여 무한 러닝 구현

* ⏱️ **체크포인트 시스템** — 통과 시 남은 시간 +5s, 장애물 스폰 텀 단축으로 난이도 상승

* 🪙 **픽업 2종** —

   **Coin**: 점수 +100, 획득 사운드

   **Apple**: 스테이지 이동 속도 ↑, 카메라 줌 아웃 연출(FOV)

* 🎥 **다이내믹 카메라** — Cinemachine 기반, 속도 변화량에 따른 FOV 보간 및 파티클 연출

* 🎯 **정교한 충돌 처리** — 쿨다운 기반 피격 트리거(애니메이션), 속도 페널티 적용

* 🧩 **경량 구조** — 매니저/플레이어/생성 시스템으로 모듈화, 씬 의존성 최소화

* 🧪 **테스트 친화적 설계** — Init()을 통한 DI 스타일 참조 주입(Score/Level 등)

<h2 id="tech-stack">🧰 기술 스택 / Tech Stack</h2>

**엔진**: Unity 6.0

**언어**: C#

**패키지/툴**: Input System, Cinemachine, TextMeshPro, Git, VS Code/Rider

**핵심 시스템 구성**

| 시스템                     | 설명                       |
| ----------------------- | ------------------------ |
| **LevelGenerator**      | 청크 스폰/파괴, 속도 조정, 중력 Z 보정, 카메라 FOV 연동 |
| **Chunk**               | 펜스/사과/코인 스폰, 레인 선택 로직                    |
| **Checkpoint**          | 시간 연장 + 장애물 스폰 텀 감소                        |
| **ObstacleSpawner**     | 프리팹 난수 선택, 일정(가변) 간격 스폰                 |
| **GameManager**         | 남은 시간 HUD, 게임오버 처리, 타임스케일               |
| **ScoreManager**        | 점수 카운트/HUD |
| **PlayerController**    | 물리 이동(Rigidbody), 경계 클램프|
| **CameraController**    | 속도 기반 FOV 보간, 파티클 재생  |
| **Pickups (Coin/Apple)**| 점수 부여/속도 조정 + 사운드 재생 |

---

<h2 id="architecture">🏗️ 프로젝트 구조 / Architecture</h2>

```
Assets/
  RoyalRun/
    Managers/
      GameManager.cs
      ScoreManager.cs
    Player/
      PlayerController.cs
      PlayerCollisionHandler.cs
      CameraController.cs
    ProcGen/
      LevelGenerator.cs
      Chunk.cs
      Checkpoint.cs
      ObstacleSpawner.cs
      ObstacleDestroy.cs
    Pickups/
      Pickup.cs
      Coin.cs
      Apple.cs
    UI/
      (TMP Texts, GameOver UI)
    Prefabs/
      Chunks/, Obstacles/, Pickups/
```

**설계 포인트**:

* DI 스타일 Init으로 런타임 의존성 주입(Chunk.Init(this, scoreManager) 등)
* 스폰/파괴 루프에서 성능 고려(필요 시 오브젝트 풀링으로 확장 용이)
* 속도 변화 → 중력/카메라/FOV를 함께 조정해 체감 속도와 피드백 일치


---

<h2 id="setup">⚙️ 설치 및 실행 / Setup</h2>

저장소 클론

git clone https://github.com/<YOUR_ID>/RoyalRun.git


Unity Hub에서 프로젝트 열기

Packages 자동 복구 후, Assets/Scenes/Demo.unity 실행

▶️ Play

에셋 의존성이 있는 경우, Readme/팝업 안내에 따라 의존 패키지를 함께 설치하세요.

<h2 id="controls">🎮 조작법 / Controls</h2>

| 동작    | 조작         |
| ----- | ---------- |
| 이동    | WASD   |

이동은 x/z 평면에서 경계(Clamp)로 제한되어 레인 이탈을 방지합니다.

---

<h2 id="screenshots">🖼️ 스크린샷 / Screenshots</h2> <p align="center"> <img src="Royal Run Main.png" width="720" alt="Royal Run Gameplay"/> <img src="Royal Run Main2.png" width="720" alt="Royal Run Gameplay"/> </p>

체크포인트를 통과하면 시간 연장과 함께 장애물 스폰 텀이 짧아집니다.

<h2 id="roadmap">🚀 향후 계획 / Roadmap</h2>

 오브젝트 풀링 도입(청크/장애물/코인)

 난이도 커브/웨이브 테이블화(속도·스폰률 곡선)

 모바일 터치/자이로 조작 추가

 리더보드 & 기록 저장

 코스 변주(점프/브릿지/낙하 트랩) 및 버프/디버프 아이템 확장

<h2 id="credits">👤 제작자 / Credits</h2>

기획·개발: 김영무 (Kim YoungMoo)

아트 리소스: Low-poly 리소스(상용/프리믹스)

사운드: 자체 제작 & 무료 라이브러리 활용


<h2 id="contact">📬 연락처 / Contact</h2>

Email: rladuan612@gmail.com

Portfolio: https://your-portfolio.link
