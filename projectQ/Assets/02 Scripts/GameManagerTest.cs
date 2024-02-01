using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    public GameObject[] Rooms;
    public float RoomX = 18.46f;
    public float RoomY = 10.25f;

    // 각 변에 문이 있는 방 타입
    private List<int> leftDoorTypes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
    private List<int> upDoorTypes = new List<int> { 3, 4, 6, 7, 11, 12, 15, 16 };
    private List<int> downDoorTypes = new List<int> { 2, 4, 5, 6, 13, 14, 15, 16 };
    private List<int> rightDoorTypes = new List<int> { 1, 5, 6, 7, 10, 12, 14, 16 };

    // 생성된 방의 위치를 저장하는 HashSet
    private HashSet<Vector3> createdPositions = new HashSet<Vector3>();

    void Awake()
    {
        Vector3 currentPos = Vector3.zero;
        int prevExit = 3; // 처음에는 오른쪽으로 이동
        createdPositions.Add(currentPos); // 초기 방 위치를 추가

        // 20개의 방을 생성
        for (int i = 0; i < 15; i++)
        {
            int roomType;
            switch (prevExit)
            {
                case 3: // 오른쪽으로 이동
                    roomType = leftDoorTypes[Random.Range(0, leftDoorTypes.Count)];
                    currentPos += new Vector3(RoomX, 0);
                    break;
                case 0: // 왼쪽으로 이동
                    roomType = rightDoorTypes[Random.Range(0, rightDoorTypes.Count)];
                    currentPos -= new Vector3(RoomX, 0);
                    break;
                case 1: // 위로 이동
                    roomType = downDoorTypes[Random.Range(0, downDoorTypes.Count)];
                    currentPos += new Vector3(0, RoomY);
                    break;
                default: // 아래로 이동
                    roomType = upDoorTypes[Random.Range(0, upDoorTypes.Count)];
                    currentPos -= new Vector3(0, RoomY);
                    break;
            }

            // 생성될 위치에 이미 방이 존재하는지 확인
            if (!createdPositions.Contains(currentPos))
            {
                // 선택한 방 타입의 방을 현재 위치에 인스턴스화
                Instantiate(Rooms[roomType], currentPos, Quaternion.identity);

                // 생성된 방의 위치를 HashSet에 추가
                createdPositions.Add(currentPos);

                // 다음에 이동할 방향을 랜덤하게 결정
                prevExit = Random.Range(0, 4);
            }
            else
            {
                // 이미 방이 존재하는 위치라면, i를 감소시켜 다시 시도
                i--;
            }
        }
    }
}
