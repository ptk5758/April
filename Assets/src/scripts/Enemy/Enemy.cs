public interface Enemy
{
    public enum Range {
        SHORTS = 5, // 근접 , 중거리, 원거리, 대기상태
        MIDDLE = 10,
        FAR = 15,
        Standby = 16
    }

    public enum Status { 
        MOVE,
        STOP,
        WARNING,
        Patrol
    }


}