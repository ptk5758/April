public interface Enemy
{
    public enum Range {
        SHORTS = 5, // ���� , �߰Ÿ�, ���Ÿ�
        MIDDLE = 10,
        FAR = 15
    }

    public enum Status { 
        MOVE,
        STOP,
        WARNING
    }


}