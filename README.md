# MetaBus

# 진행상황
- 필수 기능

캐릭터 이동 및 맵 탐색 O

맵 설계 및 상호작용 영역 O

미니 게임 실행 O

점수 시스템 O

게임 종료 및 복귀 O

카메라 추적 기능 O
  
- 도전 기능
  
추가 미니 게임 X

커스텀 캐릭터 △

리더보드 시스템 △

탑승물 제작 O

Npc와 대화 시스템 O

# 트러블 슈팅

상황 : 트리거를 발동 시킬 때 점수 화면 UI를 띄우려고 했더니 전체적인 화면에 뜨게 되었다.

원인 : Canvas의 Render Mode 를 Screen Space - Camera로 적용중이었다.

해결 : Canvas의 Render Mode 를 World Space로 변경

--

상황 : 라이딩 시스템을 구현하기 위하여 Animator의 Controller를 변경할려고 하였다.

해결 : Animator의 Controller를 변경하기 위해서는 Animator를 부르는게 아닌 RuntimeAnimatorController 를 호출하여야하였다.
