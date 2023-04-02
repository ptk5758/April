public interface Enemy
{
    public enum Range {
        SHORTS = 5, // 근접 , 중거리, 원거리
        MIDDLE = 10,
        FAR = 15
    }

    public enum Status { 
        MOVE,
        STOP,
        WARNING
    }


}