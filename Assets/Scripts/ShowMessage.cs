using UnityEngine;

public static class ShowMessage
{
    public static void WrongFileExtension()
    {
        CreateMessage("������ ������ ����� �� ��������������");
    }

    private static void CreateMessage(string messageText)
    {
        Debug.Log(messageText);
    }
}
